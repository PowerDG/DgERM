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
using Abp.Runtime.Session;
using RQCore.Authorization;
using Abp.Authorization;
using Abp.Domain.Uow;

namespace RQCore.RQAppService
{
    public class InvoiceItemService : RQCoreAppServiceBase, IInvoiceItemService
    {

        private readonly IRepository<InvoiceItem, int> _InvoiceRepository;

        private readonly IRepository<BillInfo, long> _BillInfoRepository;
        public InvoiceItemService(
            IRepository<InvoiceItem, int> InvoiceRepository, 
            IRepository<BillInfo, long> BillInfoRepository)
        {
            _InvoiceRepository = InvoiceRepository;

            _BillInfoRepository = BillInfoRepository;
        }
        public void CreateMission(InvoiceItemInput input)
        {
            var task = Mapper.Map<InvoiceItem>(input);
            task.Id = null;
            //if (task != null)
            //{ var result = _InvoiceRepository.Insert(task); }

            _InvoiceRepository.Insert(task);
        }
        [UnitOfWork]
        public int? CreateMissionQ(InvoiceItemInput input)
        {
            var task = Mapper.Map<InvoiceItem>(input);
            task.Id = null;
            if (task != null)
            {
                var result = _InvoiceRepository.Insert(task);
                CurrentUnitOfWork.SaveChanges();

                return result.Id;
            }
            else
            { return 0; }
        }
        public void UpdateMission(InvoiceItemInput input)
        {
            // var task = _InvoiceRepository.GetAll().FirstOrDefault(t => t.CargoID == input.CargoID);
            var result = Mapper.Map<InvoiceItem>(input);
           // result.Id = null;
            if (result != null)
            { _InvoiceRepository.Update(result);
            }

        }


        public string NewBalance(dynamic obj)
        {
            //// var task = _InvoiceRepository.GetAll().FirstOrDefault(t => t.CargoID == input.CargoID);
            //var result = Mapper.Map<InvoiceItem>(input);
            //// result.Id = null;
            //if (result != null)
            //{
            //    _InvoiceRepository.Update(result);
            //}

            try
            {
                foreach (string ExpressNo in obj.ExpressNo_True)
                {
                    var task = _BillInfoRepository.FirstOrDefault(t => t.ExpressNo == ExpressNo);
                    task.BillStateID = 3;
                    _BillInfoRepository.Update(task);

                }


                //foreach (string ExpressNo in obj.ExpressNo_False)
                //{
                //    var task = _BillInfoRepository.FirstOrDefault(t => t.ExpressNo == ExpressNo);
                //    task.IsDefaultShow = false;
                //    _BillInfoRepository.Update(task);
                //}

                return "成功";
            }
            catch
            {
                return "失败";
            }

        }
        public void DeleteMission(uint taskId)
        {
            var task = _InvoiceRepository.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            { _InvoiceRepository.Delete(task); }
        }
        public PagedResultDto<InvoiceItemDto> GetPagedRQAfficheInfos(SearchInvoiceItemInput input)
        {
            if (input.pageIndex == 0)
            {
                input.pageIndex = 1; 
            }
            if (input.pageSize == 0)
            {
                input.pageSize = 256;
            }
            //初步过滤
            var query = _InvoiceRepository.GetAll()
                .Where(t=>t.InvoiceNo== input.InvoiceNo)
                //.WhereIf(input.pageIndex==0,input.pageIndex)
                //.OrderByDescending(t => t.CreationTime)
                .ToList();
            //.WhereIf(input.BranchID.HasValue, t => t.BranchID == input.BranchID.Value)
            //.WhereIf(!input.CargoName.IsNullOrEmpty(), t => t.CargoName.Contains(input.CargoName));
            //排序
            //query = !string.IsNullOrEmpty(input.Sorting) ? query.OrderBy(input.Sorting) : query.OrderByDescending(t => t.CreationTime);
            // query= query.ToList();
            //获取总数
            var tasksCount = query.Count;
            //默认的分页方式 source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var taskList = query.Skip((input.pageIndex - 1) * input.pageSize).Take(input.pageSize).ToList();
            //ABP提供了扩展方法PageBy分页方式
            //var taskList = query.PageBy(input).ToList(); 
            return new PagedResultDto<InvoiceItemDto>(tasksCount, taskList.MapTo<List<InvoiceItemDto>>());
        }



        public IList<InvoiceItemDto> GetAllMissions(uint taskId)
        {
            var task = _InvoiceRepository.GetAll()
                .Where(t=>t.InvoiceNo ==taskId)
                .OrderByDescending(t => t.Id)
                .ToList();
            return Mapper.Map<List<InvoiceItemDto>>(task);
        }

        //public async Task<ListResultDto<RQAfficheDto>> GetAllRQAfficheInfo(RQAfficheDto input)
        //{
        //    var task = await _InvoiceRepository.GetAll().OrderByDescending(t => t.CargoID).ToListAsync();
        //    return new ListResultDto<RQAfficheDto>(
        //       AutoMapper.Mapper.Map<List<RQAfficheDto>>(task));
        //}

        public InvoiceItemDto GetMissionById(uint taskId)
        {
            var task = _InvoiceRepository.FirstOrDefault(t => t.Id == taskId);
            var result = Mapper.Map<InvoiceItemDto>(task);
            if (task != null)
            { return result; }
            else
            { throw new NotImplementedException(); }
        }


    }
}
