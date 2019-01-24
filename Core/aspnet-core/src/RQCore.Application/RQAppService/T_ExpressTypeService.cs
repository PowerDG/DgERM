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

namespace RQCore.RQAppService
{
    public class T_ExpressTypeService : RQCoreAppServiceBase, IT_ExpressTypeAppService
    {
        private readonly IRepository<T_ExpressType, int> _T_ExpressTypeRepository;
        public T_ExpressTypeService(IRepository<T_ExpressType, int> T_ExpressTypeRepository)
        {
            _T_ExpressTypeRepository = T_ExpressTypeRepository;
        }
        public IList<SelectStringDto> GetAllMession()
        {
            var task = (from t in _T_ExpressTypeRepository.GetAll().Where(t=>t.IsDefaultShow==true)

                        select new SelectStringDto
                        {
                            Id = t.ExpressNo,
                            Name = t.ExpressName
                        }).ToList();
            return task;


        }

        public PagedResultDto<SearchT_ExpressTypeDto> GetPagedT_ExpressTypes(SearchT_ExpressTypeInput input)
        {
            var task = _T_ExpressTypeRepository.GetAll()
                 .WhereIf(!input.ExpressName.IsNullOrEmpty(), t => t.ExpressName.Contains( input.ExpressName))
                 .WhereIf(input.IsDefaultShow.HasValue,t=>t.IsDefaultShow==Convert.ToBoolean( input.IsDefaultShow))
                 .OrderByDescending(t => t.IsDefaultShow).ToList();

            var tasklist = task.Skip((input.PageIndex - 1) * input.PageSize).Take(input.PageSize).ToList();
            var taskcount = task.Count;

            var result = new PagedResultDto<SearchT_ExpressTypeDto>(taskcount, Mapper.Map<List<SearchT_ExpressTypeDto>>(tasklist));

            return result;

        }
        /// <summary>
        /// 勾选启用快递商接口
        /// </summary>
        /// <param name="ExpressNo_True"> 勾选的要启用的快递商编号</param>
        /// <param name="ExpressNo_False">未勾选的要启用的快递商编号</param>
        /// <returns></returns>
        public string UpdateMission(dynamic obj)
        {
            try
            {
                foreach (string ExpressNo in obj.ExpressNo_True)
                {
                    var task = _T_ExpressTypeRepository.FirstOrDefault(t => t.ExpressNo ==ExpressNo);
                    task.IsDefaultShow = true;
                   _T_ExpressTypeRepository.Update(task);

                }


                foreach (string ExpressNo in obj.ExpressNo_False)
                {
                    var task = _T_ExpressTypeRepository.FirstOrDefault(t => t.ExpressNo == ExpressNo);
                    task.IsDefaultShow = false;
                    _T_ExpressTypeRepository.Update(task);
                }

                return "成功";
            }
            catch
            {
                return "失败";
            }
        }
    }
}
