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

namespace RQCore.RQAppService
{
    public class BillInfoService : RQCoreAppServiceBase, IBillInfoAppService
    {
        // Snowflake Snowflake = new Snowflake();
        private readonly IRepository<BillInfo, long> _BillInfoRepository;
        private readonly IRepository<T_GoodsImg, int> _T_GoodsImgrepository;
        private readonly IRepository<Inspection, long> _Inspectionrepository;
        private readonly IRepository<CustomerInfo, int> _CustomerInforepository;
        public BillInfoService(
            IRepository<BillInfo, long> BillInfoRepository,
            IRepository<T_GoodsImg, int> T_GoodsImgrepository,
            IRepository<Inspection, long> Inspectionrepository,
            IRepository<CustomerInfo, int> CustomerInforepository
            )
        {
            _BillInfoRepository = BillInfoRepository;
            _T_GoodsImgrepository = T_GoodsImgrepository;
            _Inspectionrepository = Inspectionrepository;
            _CustomerInforepository = CustomerInforepository;
        }


        //SortedDictionary<string, object>
        public SortedDictionary<string, object> BillInfoWithNoAndImg(int BillNO)
        {
            SortedDictionary<string, object> DgDict = new SortedDictionary<string, object>();
            if (CheckBillNo(BillNO))  //存在为BillNO的货单 
            {
                //存在为BillNO的货单 
                var task = _BillInfoRepository.FirstOrDefault(t => t.BillNo == BillNO);
                BillInfoDto BillDto //替换为NO查询单例
                    = Mapper.Map<BillInfoDto>(task);//替换为NO查询单例

                DgDict.Add("CurrentBillInfo", BillDto);

            }
            else
            {

                DgDict.Add("CurrentBillInfo", "尚无该单号之货单信息");
            }
            if (CheckBillNoImage(BillNO))//存在为BillNO的图片信息 
            {
                //存在为BillNO的图片信息 
                var task = _T_GoodsImgrepository.GetAllList(t => t.TGID == BillNO);
                List<T_GoodsImg> BillDto //BillInfo替换为NO查询图片信息集合
                    = Mapper.Map<List<T_GoodsImg>>(task);//替换为NO查询图片信息集合 当前货单信息

                DgDict.Add("CurrentBillImages", BillDto);
            }
            else
            { 
                DgDict.Add("CurrentBillInfo", "尚无该单号之货单图片");
            } 
            return DgDict;
        }


        public string CreateMission_OL(BillOnLineDto input)
        {
            try
            { 
                input.Id = Snowflake.Instance().GetId(); //分布式ID作为主键
                var result = Mapper.Map<BillInfo>(input); 
                result.UpVersion();                      //版本号加一 
                _BillInfoRepository.Insert(result); return "新增成功";
                //var task = _BillInfoRepository.GetAll()
                //    .Where(t => t.BillNo == input.BillNo && t.IsCandidate == false)
                //    .ToList().Count; //检查是否有同货票号且正在生效中信息

                //// if (input.State == 0)//货票初次录入信息

                //if (task <= 0)
                //{

                //    _BillInfoRepository.Insert(result); return "新增成功";
                //}
                //else
                //{ return "该货票单号已存在";
                //}


            }
            catch
            { return "新增失败"; }
        }



        public string CreateMission_user(BillInfoDto input)
        {
            try
            {
                input.Id = Snowflake.Instance().GetId(); //分布式ID作为主键
                var result = Mapper.Map<BillInfo>(input);
                var task = _BillInfoRepository.GetAll().
                    Where(t => t.BillNo == input.BillNo && t.IsCandidate == false)
                    .ToList().Count; //检查是否有同货票号且正在生效中信息

                // if (input.State == 0)//货票初次录入信息

                if (task <= 0)
                {

                    _BillInfoRepository.Insert(result); return "新增成功";
                }
                else
                { return "该货票单号已存在"; }


            }
            catch
            { return "新增失败"; }
        }


        public string DeleteMission_user(long taskId)
        {
            //bool canAssignInspectionToOther = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection);
            ////如果任务已经分配且未分配给自己，且不具有分配任务权限，则抛出异常
            //if (!canAssignInspectionToOther)
            //{
            //    throw new AbpAuthorizationException("没有分配任务给他人的权限！");
            //}
            //else
            //{

            //}
            var task = _BillInfoRepository.GetAll()
                .Where(t => t.Id == taskId && t.IsCandidate == false)
                .ToList().Count; //检查是否有同货票号且正在生效中信息
            if (task > 0)
            { return "提交删除审核信息成功"; }
            else
            { return "该货票信息不存在，不能提出修改"; } //原基本信息不存在，不能修删除

        }

        public string UpdateMission(BillInfoDto input)
        {

            bool canAssignInspectionToOther = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection);
            //如果任务已经分配且未分配给自己，且不具有分配任务权限，则抛出异常
            if (!canAssignInspectionToOther)
            {
                #region 修改信息处理

                input.Id = Snowflake.Instance().GetId(); //分布式ID作为主键
                var result = Mapper.Map<BillInfo>(input);
                result.UpVersion();                      //版本号加一
                result.ChangeIsCandidate();              //设为候选待审核
                _BillInfoRepository.Insert(result);

                #endregion

                #region 检查是否有同货票号且正在生效中信息

                var task = _BillInfoRepository.GetAll()
                  .Where(t => t.BillNo == input.BillNo && t.IsCandidate == false);
                #endregion



                // if (input.State == 1)//审核时提出修改信息,新增同货票号新信息，未审核通过时 IsCandidate 状态为1（未审核），同时生成对应审核表内容
                if (task.ToList().Count <= 0)
                {
                    return "该货票基本信息已被删除，不能提出修改";
                } //原基本信息不存在，不能修改
                else
                {
                    var taskss = task.Where(t => t.BillStateID == 2).ToList();//订单状态为已签收
                    if (taskss.Count>0)
                    {
                        #region 审核信息新建
                        InspectionDto inspectionDto = new InspectionDto
                        {
                            Id = null,
                            Inspection_No = Snowflake.Instance().GetId(),
                            SourceType = "货票",
                            SourceNo = task.FirstOrDefault().Id,
                            StartDate = DateTime.UtcNow,
                            DestinationNO = result.Id,
                            Version = 1,
                            ProposerName = "",
                            ProposerID = AbpSession.GetUserId(),
                            Title = "货票 修改",
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
                    }
                    else
                    {
                        #region 非已签收状态直接修改

                        try
                        {
                            var task_t = _BillInfoRepository.GetAll().Where(t => t.Id == input.Id && t.IsCandidate == false);
                            var result_t = Mapper.Map<BillInfo>(input);
                            result_t.UpVersion();                      //版本号加一
                            if (task_t != null)
                            {
                                _BillInfoRepository.Update(result_t);
                                return "修改成功";
                            }
                            else
                            { return "修改失败"; }
                        }
                        catch
                        { return "修改失败"; }
                        #endregion
                    }



                    return "提出修改成功";
                }
                //throw new AbpAuthorizationException("没有分配任务给他人的权限！");
            }
            else
            {
                #region 管理员直接修改

                try
                {
                    var task = _BillInfoRepository.GetAll().Where(t => t.Id == input.Id && t.IsCandidate == false);
                    var result = Mapper.Map<BillInfo>(input);
                    result.UpVersion();                      //版本号加一
                    if (task != null)
                    {
                        _BillInfoRepository.Update(result);
                        return "修改成功";
                    }
                    else
                    { return "修改失败"; }
                }
                catch
                { return "修改失败"; }
                #endregion

            }



        }



        public int CreateMissionQ(BillInfoDto input)
        {


            input.Id = Snowflake.Instance().GetId();
            var result = Mapper.Map<BillInfo>(input);
            var task = _BillInfoRepository.Insert(result);
            // GetMissionById(input.BillNo)
            return input.BillNo;

           

        }





        public string CreateMission_admin(BillInfoDto input)
        {
            try
            {
                input.Id = Snowflake.Instance().GetId(); //分布式ID作为主键
                var result = Mapper.Map<BillInfo>(input);
                result.UpVersion();                      //版本号加一
                var task = _BillInfoRepository.GetAll().Where(t => t.BillNo == input.BillNo && t.IsCandidate == false).ToList().Count; //检查是否有同货票号且正在生效中信息

                // if (input.State == 0)//货票初次录入信息

                if (task <= 0)
                {

                    _BillInfoRepository.Insert(result); return "新增成功";
                }
                else
                { return "该货票单号已存在"; }


            }
            catch
            { return "新增失败"; }
        }
        public string DeleteMission_admin(long taskId)
        {
            var HasI = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection); //判断是否有审核权限
            var task = _BillInfoRepository.FirstOrDefault(t => t.Id == taskId && t.IsCandidate == false);
            if (HasI)
            {
                try
                {
                  
                    var result = Mapper.Map<BillInfo>(task);

                    if (task != null)
                    { _BillInfoRepository.Delete(result); return "删除成功"; }
                    else
                    { return "资料不存在"; }

                }
                catch
                { return "删除失败"; }
            }
            else
            {
                #region 审核信息新建
                InspectionDto inspectionDto = new InspectionDto
                {
                    Id = null,
                    Inspection_No = Snowflake.Instance().GetId(),
                    SourceType = "货票",
                    SourceNo = task.Id,
                    StartDate = DateTime.UtcNow,
                    DestinationNO = task.Id,
                    Version = 1,
                    ProposerName = "",
                    ProposerID = AbpSession.GetUserId(),
                    Title = "货票 删除",
                    IsCandidate = true,
                    InspectionState = 0,
                    InspectionName = null,
                    Action = "删除",
                    InspectionMemo = "",
                    EndDate = null,
                    Quality_level = 1

                };
                var inspection = Mapper.Map<Inspection>(inspectionDto);
                _Inspectionrepository.Insert(inspection);
                #endregion
                return "已提出删除申请";
            }


        }


        //public async Task<ListResultDto<BillInfoDto>> GetAllBillInfo(BillInfoDto input)
        //{
        //    var task = await _BillInfoRepository.GetAll()              
        //        .OrderByDescending(t => t.BillNo)
        //        .ToListAsync();
        //    if (task != null)
        //    { return Mapper.Map<ListResultDto<BillInfoDto>>(task); }
        //    else
        //    { throw new NotImplementedException(); }

        //}

        public IList<BillInfoDto> GetAllMissions()
        {
            var task = _BillInfoRepository.GetAll().Where(t => t.IsCandidate == false)
                .OrderByDescending(t => t.Id)
                .ToList();
            return Mapper.Map<List<BillInfoDto>>(task);

        }

        public BillInfoDto GetMissionById(long taskId)
        {
            var HasI = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection); //判断是有权限
            var task = _BillInfoRepository.FirstOrDefault(t => t.Id == taskId );
            if (HasI==true)  //有审核权限则直接查看所有
            {
                return Mapper.Map<BillInfoDto>(task);
            }
            else
            {
                if (task.BillStateID < 2)  
                {
                                        
                    return Mapper.Map<BillInfoDto>(task);
                }
                else   //若货单状态为已签收，则发起查看申请到审核表
                {  //若状态为已签收，且已经发起申请，且申请通过，则可以直接查看
                    var tasks = _Inspectionrepository.GetAll()
                           .Where(t => t.IsCandidate == true && t.InspectionState == 1 && taskId == t.SourceNo).ToList();
                    if (tasks.Count > 0)
                    {
                        return Mapper.Map<BillInfoDto>(task);
                    }
                    else
                    { 

                    #region MyRegion


                    InspectionDto inspectionDto = new InspectionDto
                    {
                        Id = null,
                        Inspection_No = Snowflake.Instance().GetId(),
                        SourceType = "货票",
                        SourceNo = task.Id,
                        StartDate = DateTime.UtcNow,
                        DestinationNO = task.Id,
                        Version = 1,
                        ProposerName = "",
                        ProposerID = 11, //AbpSession.GetUserId(),
                        Title = "货票 查看",
                        IsCandidate = true,
                        InspectionState = 0,
                        InspectionName = null,
                        Action = "查看",
                        InspectionMemo = "",
                        EndDate = null,
                        Quality_level = 1

                    };
                    var inspection = Mapper.Map<Inspection>(inspectionDto);
                    _Inspectionrepository.Insert(inspection);
                    #endregion

                    return null;
                    }
                }
            }


        }

        public PagedResultDto<SearchBIllInfoDto> GetPagedBillInfos(SearchBillInfoInput input)
        {

            bool Has;
            var HasI = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection); //判断是有权限
            if (!HasI)
            {

                Has = PermissionChecker.IsGranted(PermissionNames.Pages_Staff_Merchandiser); //判断是否业务员

            }
            else
            {
                Has = false;
            }
            // var UserID = AbpSession.GetUserId();
            List<BillInfo> task;                                                                 //按条件过滤
            if (input.BillNo.HasValue)
            {
                task = _BillInfoRepository.GetAll().OrderByDescending(t => t.Id)
               .Where(t => t.IsCandidate == false)
               .WhereIf(input.BillNo.HasValue, t => t.BillNo == input.BillNo)
               .WhereIf(!input.CompanyAbbreviation.IsNullOrEmpty(), t => t.CompanyAbbreviation == input.CompanyAbbreviation)
               .WhereIf(!input.ReceivingCity.IsNullOrEmpty(), t => t.ReceivingCity == input.ReceivingCity)
               .WhereIf(input.CreationTimeS.HasValue, t => t.CreationTime >= input.CreationTimeS)
               .WhereIf(input.CreationTimeE.HasValue, t => t.CreationTime <= input.CreationTimeE)
               .WhereIf(Has,t=>t.MerchandiserId==input.UserId)
                     .OrderByDescending(t => t.CreationTime)
                .ToList();

              
                

                
               // task[0].BillStateID>=2
            }
            else
            {
               task = _BillInfoRepository.GetAll().OrderByDescending(t => t.Id)
               .Where(t => t.IsCandidate == false)
               .WhereIf(input.BillNo.HasValue, t => t.BillNo == input.BillNo)
               .WhereIf(!input.CompanyAbbreviation.IsNullOrEmpty(), t => t.CompanyAbbreviation == input.CompanyAbbreviation)
               .WhereIf(!input.ReceivingCity.IsNullOrEmpty(), t => t.ReceivingCity == input.ReceivingCity)
               .WhereIf(input.CreationTimeS.HasValue, t => t.CreationTime >= input.CreationTimeS)
               .WhereIf(input.CreationTimeE.HasValue, t => t.CreationTime <= input.CreationTimeE)
               .WhereIf(Has, t => t.MerchandiserId == input.UserId)
               .WhereIf(!HasI,t=>t.BillStateID<2)
                  //HasI 判断是有权限审核 已签收不显示


                  .OrderByDescending(t => t.CreationTime)
             .ToList();


            } 
            //var task = _BillInfoRepository.GetAll().OrderByDescending(t => t.Id)
            //    .Where(t => t.IsCandidate == false)
            //    .WhereIf(input.BillNo.HasValue, t => t.BillNo == input.BillNo)
            //    .WhereIf(!input.CompanyAbbreviation.IsNullOrEmpty(), t => t.CompanyAbbreviation == input.CompanyAbbreviation)
            //    .WhereIf(!input.ReceivingCity.IsNullOrEmpty(), t => t.ReceivingCity == input.ReceivingCity)
            //    .WhereIf(input.CreationTimeS.HasValue, t => t.CreationTime >= input.CreationTimeS)
            //    .WhereIf(input.CreationTimeE.HasValue, t => t.CreationTime <= input.CreationTimeE)

            //    //.WhereIf(!input.BillNo.IsNullOrEmpty(), t => t.ReceivingCity == input.ReceivingCity))
            //   // .WhereIf(Has,t=>t.CreatorUserId== UserID)
            //    .OrderByDescending(t => t.CreationTime)
            //    .ToList();

            var taskcount = task.Count;  //数据总量

            var tasklist = task.Skip((input.PageIndex - 1) * input.PageSize).Take(input.PageSize).ToList();  //获取目标页数据

            var result = new PagedResultDto<SearchBIllInfoDto>(taskcount, tasklist.MapTo<List<SearchBIllInfoDto>>());

            return result;

        }

        public PagedResultDto<BillInfoBusinessDto> GetPagedBusiness(SearchBillInfoInput input)  //业务清单
        {
            var Has = PermissionChecker.IsGranted(PermissionNames.Pages_Staff_Merchandiser); //判断是否业务员


            var HasI = PermissionChecker.IsGranted(PermissionNames.Pages_Inspection); //判断是有权限

            var  task = _BillInfoRepository.GetAll().OrderByDescending(t => t.Id)
               .Where(t => t.IsCandidate == false)
               .WhereIf(input.BillNo.HasValue, t => t.BillNo == input.BillNo)
               .WhereIf(!input.CompanyAbbreviation.IsNullOrEmpty(), t => t.CompanyAbbreviation.Contains( input.CompanyAbbreviation))
               .WhereIf(!input.ReceivingCity.IsNullOrEmpty(), t => t.ReceivingCity == input.ReceivingCity)
               .WhereIf(input.CreationTimeS.HasValue, t => t.CreationTime >= input.CreationTimeS)
               .WhereIf(input.CreationTimeE.HasValue, t => t.CreationTime <= input.CreationTimeE)
               .WhereIf(!input.ExpressNo.IsNullOrEmpty(),t=>t.ExpressNo==input.ExpressNo)

               .WhereIf(!HasI, t => t.BillStateID < 2)
               .OrderByDescending(t => t.CreationTime)
                .ToList();

      
            var taskcount = task.Count;  //数据总量

            var tasklist = task.Skip((input.PageIndex - 1) * input.PageSize).Take(input.PageSize).ToList();  //获取目标页数据

            var result = new PagedResultDto<BillInfoBusinessDto>(taskcount, tasklist.MapTo<List<BillInfoBusinessDto>>());

            return result;

        }

        //public int GetKeyId(int taskid)
        //{

        //    var task = (from r in _BillInfoRepository.GetAll()
        //                where (r.BillNo == taskid)
        //                select r.BillNo).Distinct();
        //    if (task != null)
        //    {
        //        int result = Convert.ToInt32(task);
        //        return result;
        //    }
        //    else
        //    { return 0; }

        //}

        //public async Task<BillInfoDto> GetMissionByIdAsync(int taskId)
        //{
        //    var task = await _BillInfoRepository.GetAll()
        //        .Where(t => t.BillNo == taskId)
        //       .OrderByDescending(t => t.BillNo)
        //       .ToListAsync();
        //    if (task != null)
        //    { return Mapper.Map<BillInfoDto>(task); }
        //    else
        //    { throw new NotImplementedException(); }
        //}

        public IList<SearchBIllInfoDto> GetAllBillInfoDto()
        {
            var task = _BillInfoRepository.GetAll().OrderByDescending(t => t.Id).ToList();
            var result = task.MapTo<List<SearchBIllInfoDto>>();
            return result;
        }
        public IList<SelectDto> GetAllCompanyList()
        {
            var task = (from r in _CustomerInforepository.GetAll()
                        select new SelectDto
                        {
                            Id = r.CustomerID,
                            Name = r.CompanyAbbreviation
                        }).Distinct().ToList();

            return task;
        }

        public bool CheckBillNo(int BillNO) //根据billno检查是否有数据，bool
        {
            var task = _BillInfoRepository.GetAll()
                .Where(t => t.BillNo == BillNO);
            if (task != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public BillInfoDto CheckBillInfo(int BillNo)//根据billno检查是否有数据，有则返回数据
        {
            var task = _BillInfoRepository
                   .FirstOrDefault(t => t.BillNo == BillNo && t.IsCandidate==false);
            if (task != null)
            {
                return Mapper.Map<BillInfoDto>(task);
            }
            else
            {
                return null;
            }

        }
        public bool CheckBillNoImage(int BillNO)
        {

            var task = _T_GoodsImgrepository.GetAll()
                .Where(t => t.TGID == BillNO);

            if (task != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string Balance(long[] tasklist)
        {
            var snowId = Snowflake.Instance().GetId();
            if(tasklist.Count()>0)
            {
                foreach (long taskid in tasklist)
                {
                    var task = _BillInfoRepository.FirstOrDefault(t => t.Id == taskid &&t.IsCandidate==false);
                    task.BalanceNo = snowId;
                    task.BillCheck = true;
                    task.BillStateID = 3;
                    _BillInfoRepository.Update(task);
                }
                return "开票成功";
            }
            else
            {
                return "开票失败";
            }
        }




    }
}
