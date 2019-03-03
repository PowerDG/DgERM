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
    public class InvoiceInfoService : RQCoreAppServiceBase, IInvoiceInfoService
    {

        private readonly IRepository<InvoiceInfo, int> _InvoiceRepository;
        public InvoiceInfoService(IRepository<InvoiceInfo, int> InvoiceRepository)
        {
            _InvoiceRepository = InvoiceRepository;
        }
        public void CreateMission(InvoiceInfoDto input)
        {
            var task = Mapper.Map<InvoiceInfo>(input);
            task.Id = null;
            //if (task != null)
            //{ var result = _InvoiceRepository.Insert(task); }

            _InvoiceRepository.Insert(task);
        }
        [UnitOfWork]
        public int? CreateMissionQ(InvoiceInfoDto input)
        {
            var task = Mapper.Map<InvoiceInfo>(input);
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
        public void UpdateMission(InvoiceInfoDto input)
        {
            // var task = _InvoiceRepository.GetAll().FirstOrDefault(t => t.CargoID == input.CargoID);
            var result = Mapper.Map<InvoiceInfo>(input);
            result.Id = null;
            if (result != null)
            { _InvoiceRepository.Update(result); }

        }
        public void DeleteMission(int taskId)
        {
            var task = _InvoiceRepository.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            { _InvoiceRepository.Delete(task); }
        }
        public PagedResultDto<InvoiceInfoDto> GetPagedRQAfficheInfos(SearchInvoiceInput input)
        {
            //初步过滤
            var query = _InvoiceRepository.GetAll().OrderByDescending(t => t.CreationTime).ToList();
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
            return new PagedResultDto<InvoiceInfoDto>(tasksCount, taskList.MapTo<List<InvoiceInfoDto>>());
        }



        public IList<InvoiceInfoDto> GetAllMissions()
        {
            var task = _InvoiceRepository.GetAll().OrderByDescending(t => t.Id).ToList();
            return Mapper.Map<List<InvoiceInfoDto>>(task);
        }

        //public async Task<ListResultDto<RQAfficheDto>> GetAllRQAfficheInfo(RQAfficheDto input)
        //{
        //    var task = await _InvoiceRepository.GetAll().OrderByDescending(t => t.CargoID).ToListAsync();
        //    return new ListResultDto<RQAfficheDto>(
        //       AutoMapper.Mapper.Map<List<RQAfficheDto>>(task));
        //}

        public InvoiceInfoDto GetMissionById(uint taskId)
        {
            var task = _InvoiceRepository.FirstOrDefault(t => t.Id == taskId);
            var result = Mapper.Map<InvoiceInfoDto>(task);
            if (task != null)
            { return result; }
            else
            { throw new NotImplementedException(); }
        }


    }
}
