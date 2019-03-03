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
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.Authorization;
using RQCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RQCore.RQAppService
{
    public class CustomerInfoService : RQCoreAppServiceBase, ICustomerInfoAppService
    {
        private readonly IRepository<Inspection, long> _Inspectionrepository;
        private readonly IRepository<CustomerInfo, int> _CustomerinfoRepository;
        public CustomerInfoService(IRepository<CustomerInfo, int> CustomerinfoRepository,IRepository<Inspection, long> Inspectionrepository)
        {
            _CustomerinfoRepository = CustomerinfoRepository;
            _Inspectionrepository = Inspectionrepository;
        }
        public string CreateMission(CustomerInfoDto input)
        {
            var test = _CustomerinfoRepository.FirstOrDefault(t=>t.CustomerID==input.CustomerID && t.IsCandidate == false);
            if(test==null)
            {
                var task = Mapper.Map<CustomerInfo>(input);
                task.Id = null;
                _CustomerinfoRepository.Insert(task);
                return "成功";
            }
            else
            {
                return "该客户编号已存在";
            }
           
        }
       
        public CustomerInfoDto CheckCusId(int CustomerID) //检查CustomerID 是否已存在
        {
            var task = _CustomerinfoRepository.FirstOrDefault(t => t.CustomerID == CustomerID && t.IsCandidate==false);
            if (task!=null)
            {
                return Mapper.Map<CustomerInfoDto>(task);
            }
            else
            {
                return null;
            }
        }

        [UnitOfWork]
        public int? CreateMissionQ(CustomerInfoDto input)
        {
           
            var task = Mapper.Map<CustomerInfo>(input);
            task.Id = null;
           var result= _CustomerinfoRepository.Insert(task);
            CurrentUnitOfWork.SaveChanges();
            return result.Id;
        }

        public void DeleteMission(int taskId)
        {
            var task = _CustomerinfoRepository.FirstOrDefault(t=>t.Id == taskId);
            _CustomerinfoRepository.Delete(task);
        }

        public IList<CustomerInfoDto> GetAllMissions()
        {
            var task = _CustomerinfoRepository.GetAll().Where(t=>t.IsCandidate==false).OrderByDescending(t=>t.CustomerID).ToList();
            var result = new List<CustomerInfoDto>(Mapper.Map<List<CustomerInfoDto>>(task));
            return result;
        }

        public List<SelectDto> GetCustomerIDList()  //客户下拉接口
        {
            var task = (from r in _CustomerinfoRepository.GetAll()
                        where (r.IsCandidate==false)
                        select new SelectDto { Id =Convert.ToInt32(r.Id), Name = r.CompanyAbbreviation }).ToList();
            return task;
        }

        public CustomerInfoDto GetMissionById(int taskId)
        {
            var task = _CustomerinfoRepository.FirstOrDefault(t=>t.Id==taskId );
            var result = Mapper.Map<CustomerInfoDto>(task);
            return result;
        }

        public CustomerInfoSimpleDto GetCustomerSimpleById(int taskId)
        {
            var task = _CustomerinfoRepository.FirstOrDefault(t => t.Id == taskId && t.IsCandidate == false);
            var result = Mapper.Map<CustomerInfoSimpleDto>(task);
            return result;
        }

        public PagedResultDto<SearchCustomerInfoDto> GetPagedCustomerInfos(SearchCustomerInfoInput input)
        { 
            //public string MerchandiserName { get; set; }
            //    public long MerchandiserId { get; set; }

            bool isa ;
            bool canAssignInspectionToOther = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection);
            if (!canAssignInspectionToOther)
            {
                isa= PermissionChecker.IsGranted(PermissionNames.Pages_Staff_Merchandiser);
            }

            //条件过滤
            var query = _CustomerinfoRepository.GetAll().Where(t => t.IsCandidate == false)
                .WhereIf(!input.InvoiceType.IsNullOrEmpty(), t => t.InvoiceType == input.InvoiceType)
                .WhereIf(!input.CompanyName.IsNullOrEmpty(), t => t.CompanyName == input.CompanyName)
                .WhereIf(!input.CompanyAbbreviation.IsNullOrEmpty(), t => t.CompanyName.Contains(input.CompanyAbbreviation))
                .OrderByDescending(t=>t.CustomerID);
            //获取数据总数
            var tasksCount = query.Count();
            //默认的分页方式 source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var taskList = query.Skip((input.pageIndex - 1) * input.pageSize).Take(input.pageSize).ToList();

            return new PagedResultDto<SearchCustomerInfoDto>(tasksCount, taskList.MapTo<List<SearchCustomerInfoDto>>());
        }

        public IList<SearchCustomerInfoDto> GetAllSearchDto()
        {
            var task = _CustomerinfoRepository.GetAllList().Where(t => t.IsCandidate == false);

            var result = task.MapTo<List<SearchCustomerInfoDto>>();
            return result;
        }
        [UnitOfWork]
        public string UpdateMission(CustomerInfoDto input)
        {
           
            #region 修改信息处理

          //  input.Id =null; //分布式ID作为主键
            var result = Mapper.Map<CustomerInfo>(input);
            result.UpVersion();                      //版本号加一
            result.ChangeIsCandidate();              //设为候选待审核
            _CustomerinfoRepository.Insert(result);
            CurrentUnitOfWork.SaveChanges();

            #endregion

            #region 检查是否有同货票号且正在生效中信息

            var task = _CustomerinfoRepository.GetAll()
              .Where(t => t.CustomerID == input.CustomerID && t.IsCandidate == false);
            #endregion



            // if (input.State == 1)//审核时提出修改信息,新增同货票号新信息，未审核通过时 IsCandidate 状态为1（未审核），同时生成对应审核表内容
            if (task.ToList().Count <= 0)
            {
                return "该货票基本信息已被删除，不能提出修改";
            } //原基本信息不存在，不能修改
            else
            {
                #region 审核信息新建
                InspectionDto inspectionDto = new InspectionDto
                {
                    Id = null,
                    Inspection_No = Snowflake.Instance().GetId(),
                    SourceType = "客户",
                    SourceNo =Convert.ToInt64( task.FirstOrDefault().Id),
                    StartDate = DateTime.UtcNow,
                    DestinationNO = Convert.ToInt64(result.Id),
                    Version = 1,
                    ProposerName = "",
                    ProposerID = AbpSession.GetUserId(),
                    Title = "客户 修改",
                    IsCandidate = true,
                    InspectionState = 0,
                    InspectionName = null,
                    Action = "修改",
                    InspectionMemo = "",
                    EndDate = null,
                    Quality_level = 1

                };
                var inspection = Mapper.Map<Inspection>(inspectionDto);
                _Inspectionrepository.Insert(inspection);
                #endregion


                return "提出修改成功";
            }
        }
       


    }
}
