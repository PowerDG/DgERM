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
using Abp.Authorization;
using RQCore.Authorization;

namespace RQCore.RQAppService
{
    public  class InspectionAppService : RQCoreAppServiceBase, IInspectionAppService
    {

        private readonly IRepository<Inspection, long> _Inspectionrepository;
        private readonly IRepository<BillInfo, long> _BillInfoRepository;
        private readonly IRepository<CustomerInfo, int> _CustomerInfoRepository;
        public InspectionAppService(
            IRepository<Inspection, long> Inspectionrepository,
             IRepository<BillInfo, long> BillInfoRepository,
             IRepository<CustomerInfo, int> CustomerInfoRepository
            )
        {
            _Inspectionrepository = Inspectionrepository;
            _BillInfoRepository = BillInfoRepository;
            _CustomerInfoRepository = CustomerInfoRepository;
        }
        public PagedResultDto<SearchInspectionDto> GetAllInspection(SearchInspectionInput input)
        {
            var query = _Inspectionrepository.GetAll()
                     //.WhereIf(input.BillNo.HasValue, t => t.BillNo == input.BillNo)
                       .WhereIf(!input.Action_Search.IsNullOrEmpty(), t => t.Action == input.Action_Search)
                       .WhereIf(!input.SourceType.IsNullOrEmpty(), t => t.SourceType == input.SourceType)
                       .WhereIf(input.StartDate.HasValue, t => t.StartDate >= input.StartDate)
                       .WhereIf(input.EndDate.HasValue, t => t.EndDate <= input.EndDate)
                       .OrderByDescending(t => t.CreationTime);
            if (!string.IsNullOrEmpty(input.Sorting))//排序字段是否有值
                query = query.OrderBy(t => t.Sorting);
            else
            {
                query = query.OrderByDescending(t => t.CreationTime);
            }

            var task = query.ToList();

            var taskcount = task.Count;  //数据总量

            var tasklist = task.Skip((input.PageIndex - 1) * input.PageSize).Take(input.PageSize).ToList();  //获取目标页数据

            var result = new PagedResultDto<SearchInspectionDto>(taskcount, tasklist.MapTo<List<SearchInspectionDto>>());

            return result;

            //throw new NotImplementedException();
        }
         
        public InspectionDto GetInspection(InspectionDto input)
        {
            throw new NotImplementedException();
        }

        public InspectionDto CreateInspection(InspectionDto input)
        {
            throw new NotImplementedException();
        }

        public void CreateMission(InspectionDto input)
        {
            var task = Mapper.Map<Inspection>(input);
            task.Id = null;
            task.Inspection_No = Snowflake.Instance().GetId();
            _Inspectionrepository.Insert(task);
        }
        [UnitOfWork]
        public long? CreateMissionQ(InspectionDto input)
        {
            var task = Mapper.Map<Inspection>(input);
            task.Id = null;
            //  long NO = ShortSnowflake.Instance().GetId();
            var result = _Inspectionrepository.Insert(task);
            CurrentUnitOfWork.SaveChanges();
            return result.Id;
        }


        /// <summary>
        /// 货票Bill表审核动作
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public string InspectionResult(dynamic dynamic)
        {
            #region
           
            long Inspection_No = Convert.ToInt64(dynamic.Inspection_No);   //取得审核表主键，定位
            int InspectionState = Convert.ToInt32(dynamic.InspectionState); //取得审核结果
            string Name = Convert.ToString(dynamic.Name);                    //取得审核人姓名
            string Actions = Convert.ToString(dynamic.Actions);                  //取得申请的操作动作
            var task = _Inspectionrepository.FirstOrDefault(t => t.Inspection_No == Inspection_No);  //取得当前审核表信息
            #endregion



          

            if (Actions=="修改")
            { 

                if (InspectionState == 1)   //审核通过
                {
                    #region 审核通过，启用新数据，弃用旧数据

                var Bill_New = _BillInfoRepository.FirstOrDefault(t => t.Id == task.SourceNo);  //新数据
                Bill_New.IsCandidate = false;   //更改状态 0正在使用
                _BillInfoRepository.Update(Bill_New);


                var Bill_Old = _BillInfoRepository.FirstOrDefault(t => t.Id == Convert.ToInt64(task.DestinationNO)); //旧数据，弃用
                Bill_Old.IsCandidate = true;  //更改状态    1候选状态
                _BillInfoRepository.Update(Bill_Old);
                #endregion
                }

                else if (InspectionState == 2) //审核不通过，驳回

                {
                    #region 审核不通过，新数据弃用，依旧弃用旧数据
                var Bill_New = _BillInfoRepository.FirstOrDefault(t => t.Id == task.SourceNo);  //新数据弃用 
                Bill_New.IsCandidate = true;   //更改状态 1候选状态，弃用
                _BillInfoRepository.Update(Bill_New);

                var Bill_Old = _BillInfoRepository.FirstOrDefault(t => t.Id == Convert.ToInt64(task.DestinationNO)); //旧数据，启用
                Bill_Old.IsCandidate = false;  //更改状态    0正在使用
                _BillInfoRepository.Update(Bill_Old);
                #endregion
                }

                #region 更改审核表状态
                var Inspection = _Inspectionrepository.FirstOrDefault(t => t.Inspection_No == Inspection_No);  //取得当前审核表信息
                Inspection.IsCandidate = false;          //更改状态 0正在使用
                Inspection.InspectionState = InspectionState;  //更改 审批状态
                Inspection.EndDate = DateTime.Now;  //审核时间更改
                Inspection.InspectionName = Name; //AbpSession.GetUserId().ToString();  前端提供  当前审核人姓名
                _Inspectionrepository.Update(Inspection);
                #endregion
            }
            else if(Actions=="查看") //只更改审核表信息
            {
                #region 更改审核表状态
                var Inspection = _Inspectionrepository.FirstOrDefault(t => t.Inspection_No == Inspection_No);  //取得当前审核表信息
                Inspection.IsCandidate = false;          //更改状态 0正在使用
                Inspection.InspectionState = InspectionState;  //更改 审批状态
                Inspection.EndDate = DateTime.Now;  //审核时间更改
                Inspection.InspectionName = Name; //AbpSession.GetUserId().ToString();  前端提供  当前审核人姓名
                _Inspectionrepository.Update(Inspection);
                #endregion
            }
            else if (Actions == "删除")
            {
                #region 更改审核表状态
                var Inspection = _Inspectionrepository.FirstOrDefault(t => t.Inspection_No == Inspection_No);  //取得当前审核表信息
                Inspection.IsCandidate = false;          //更改状态 0正在使用
                Inspection.InspectionState = InspectionState;  //更改 审批状态
                Inspection.EndDate = DateTime.Now;  //审核时间更改
                Inspection.InspectionName = Name; //AbpSession.GetUserId().ToString();  前端提供  当前审核人姓名
                _Inspectionrepository.Update(Inspection);
                #endregion

                #region 删除原数据
                 _BillInfoRepository.Delete(t => t.Id == Inspection.SourceNo);
                #endregion
            }

            return "审核结束";
        }

        /// <summary>
        /// 客户CustomerInfo表审核动作
        /// </summary>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public string CustomerInfoResult(dynamic dynamic)
        {
            #region

            long Inspection_No = Convert.ToInt64(dynamic.Inspection_No);   //取得审核表主键，定位
            int InspectionState = Convert.ToInt32(dynamic.InspectionState); //取得审核结果
            string Name = Convert.ToString(dynamic.Name);                    //取得审核人姓名
            string Actions = Convert.ToString(dynamic.Actions);                  //取得申请的操作动作
            var task = _Inspectionrepository.FirstOrDefault(t => t.Inspection_No == Inspection_No);  //取得当前审核表信息
            #endregion





            if (Actions == "修改")
            {

                if (InspectionState == 1)   //审核通过
                {
                    #region 审核通过，启用新数据，弃用旧数据

                    var Customer_New = _CustomerInfoRepository.FirstOrDefault(t => t.Id == task.SourceNo);  //新数据
                    Customer_New.IsCandidate = false;   //更改状态 0正在使用
                    _CustomerInfoRepository.Update(Customer_New);


                    var Customer_Old = _CustomerInfoRepository.FirstOrDefault(t => t.Id == Convert.ToInt64(task.DestinationNO)); //旧数据，弃用
                    Customer_Old.IsCandidate = true;  //更改状态    1候选状态
                    _CustomerInfoRepository.Update(Customer_Old);
                    #endregion
                }

                else if (InspectionState == 2) //审核不通过，驳回

                {
                    #region 审核不通过，新数据弃用，依旧弃用旧数据
                    var Customer_New = _CustomerInfoRepository.FirstOrDefault(t => t.Id == task.SourceNo);  //新数据弃用 
                    Customer_New.IsCandidate = true;   //更改状态 1候选状态，弃用
                    _CustomerInfoRepository.Update(Customer_New);

                    var Customer_Old = _CustomerInfoRepository.FirstOrDefault(t => t.Id == Convert.ToInt64(task.DestinationNO)); //旧数据，启用
                    Customer_Old.IsCandidate = false;  //更改状态    0正在使用
                    _CustomerInfoRepository.Update(Customer_Old);
                    #endregion
                }

                #region 更改审核表状态
                var Inspection = _Inspectionrepository.FirstOrDefault(t => t.Inspection_No == Inspection_No);  //取得当前审核表信息
                Inspection.IsCandidate = false;          //更改状态 0正在使用
                Inspection.InspectionState = InspectionState;  //更改 审批状态
                Inspection.EndDate = DateTime.Now;  //审核时间更改
                Inspection.InspectionName = Name; //AbpSession.GetUserId().ToString();  前端提供  当前审核人姓名
                _Inspectionrepository.Update(Inspection);
                #endregion
            }
            else if (Actions == "查看") //只更改审核表信息
            {
                #region 更改审核表状态
                var Inspection = _Inspectionrepository.FirstOrDefault(t => t.Inspection_No == Inspection_No);  //取得当前审核表信息
                Inspection.IsCandidate = false;          //更改状态 0正在使用
                Inspection.InspectionState = InspectionState;  //更改 审批状态
                Inspection.EndDate = DateTime.Now;  //审核时间更改
                Inspection.InspectionName = Name; //AbpSession.GetUserId().ToString();  前端提供  当前审核人姓名
                _Inspectionrepository.Update(Inspection);
                #endregion
            }

            return "审核结束";
        }

        /// <summary>
        /// 非管理员只能看自己提出的申请
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagedResultDto<SearchInspectionDto> GetAllInspectionBySelf(SearchInspectionInput input)
        {
            var HasI = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection); //判断是有权限

            var query = _Inspectionrepository.GetAll()
                       //.WhereIf(input.BillNo.HasValue, t => t.BillNo == input.BillNo)
                       .WhereIf(!input.Action_Search.IsNullOrEmpty(), t => t.Action == input.Action_Search)
                       .WhereIf(!input.SourceType.IsNullOrEmpty(), t => t.SourceType == input.SourceType)
                       .WhereIf(input.StartDate.HasValue, t => t.StartDate >= input.StartDate)
                       .WhereIf(input.EndDate.HasValue, t => t.EndDate <= input.EndDate)
                       .WhereIf(!HasI,t=>t.CreatorUserId==input.ProposerID)
                       .OrderByDescending(t => t.CreationTime);
            if (!string.IsNullOrEmpty(input.Sorting))//排序字段是否有值
                query = query.OrderBy(t => t.Sorting);
            else
            {
                query = query.OrderByDescending(t => t.CreationTime);
            }

            var task = query.ToList();

            var taskcount = task.Count;  //数据总量

            var tasklist = task.Skip((input.PageIndex - 1) * input.PageSize).Take(input.PageSize).ToList();  //获取目标页数据

            var result = new PagedResultDto<SearchInspectionDto>(taskcount, tasklist.MapTo<List<SearchInspectionDto>>());

            return result;

            //throw new NotImplementedException();
        }
        /// <summary>
        /// 个人消息数量接口
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetCount(long userId)
        {
            var HasI = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection); //判断是有权限
            var task = _Inspectionrepository.GetAll()
                .WhereIf(!HasI, t => t.CreatorUserId == userId)
                .Count();
            return task;
        }
    }
}
