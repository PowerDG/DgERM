using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RQCore.RQDtos;
using RQCore.RQEnitity;
using Abp.Extensions;
using RQCore.IRQAppService;
using RQCore.RQAppService;

namespace RQCore.RQAppService
{
    public class LogisticsInfoService : ILogisticsInfoAppService
    {
        private readonly IRepository<LogisticsInfo, int> _LogisticsInfoRepository;
        private readonly IRepository<StateInfo, int> _StateInfoRepository;
        private readonly IRepository<BillInfo, long> _BillInfoRepository;
     
        public LogisticsInfoService(
            IRepository<LogisticsInfo, int> Repository,
            IRepository<StateInfo, int> StateInfoRepository,
            IRepository<BillInfo, long> BillInfoRepository

            )
        {
            _LogisticsInfoRepository = Repository;
            _StateInfoRepository = StateInfoRepository;
            _BillInfoRepository = BillInfoRepository;

        }

        public int CreateMissionQ(LogisticsInfoDto input)
        {
            var task = Mapper.Map<LogisticsInfo>(input);
            task.Id = null;
            var result = _LogisticsInfoRepository.InsertAndGetId(task);

            var Bill = _BillInfoRepository.FirstOrDefault(t => t.BillNo == task.BillNo && t.IsCandidate==false); //同步更新货票表里面的快递状态
            if(input.State==3)
            {
                Bill.BillStateID = 2;
            }
           
            _BillInfoRepository.Update(Bill);
            return result;
        }

        public IList<SearchLogisticsInfoDto> GetLogisticsInfo(long taskId)
        {

            var task = (from r in _LogisticsInfoRepository.GetAll()
                        where (r.BillNo == taskId)
                        join t in _StateInfoRepository.GetAll() on r.State equals t.Id
                        select new SearchLogisticsInfoDto
                        {
                            Time = r.FillDate,
                            Context = t.Meaning + " " + r.Infomation
                        }).OrderByDescending(t => t.Time).ToList();

            //var result = Mapper.Map<List<SearchLogisticsInfoDto>>(task);

            return task;
        }

        public IList<SelectDto> GetLogisticsState()
        {
            var task = (from t in _StateInfoRepository.GetAll()
                        select new SelectDto
                        {
                            Id = t.Id,
                            Name = t.Meaning

                        }).OrderBy(r => r.Id).ToList();
            return task;
        }
        public SortedDictionary<string, object> Getsendinfo(int BillNo)
        {
            SortedDictionary<string, object> LogisticsInfo = new SortedDictionary<string, object>();
            var task = _BillInfoRepository.FirstOrDefault(t => t.BillNo == BillNo);
            if (task != null)
            {
                if (task.SERVICELEVEL == "2" || task.SERVICELEVEL == "3" || task.SERVICELEVEL == "4")
                {
                    var result = Send100.Instance().Get(task.ExpressNo, Convert.ToString(task.ExpressBillNo));
                    LogisticsInfo.Add("快递", result);
                    return LogisticsInfo;
                }
                else
                {
                    var result = (from r in _LogisticsInfoRepository.GetAll()
                                  where (r.BillNo == BillNo)
                                  join t in _StateInfoRepository.GetAll() on r.State equals t.Id
                                  select new SearchLogisticsInfoDto
                                  {
                                      Time = r.FillDate,
                                      Context = t.Meaning + " " + r.Infomation
                                  }).OrderByDescending(t => t.Time).ToList();

                    LogisticsInfo.Add("瑞庆", result);
                    return LogisticsInfo;
                }

            }
            else
            {
                return null;
            }
      
        }
    }
}
