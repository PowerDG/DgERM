using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RQCore.RQDtos;

namespace RQCore.IRQAppService
{
    public interface IInvoiceInfoService : IApplicationService
    {

        void CreateMission(InvoiceInfoDto input);
        int? CreateMissionQ(InvoiceInfoDto input);

        void UpdateMission(InvoiceInfoDto input);


        void DeleteMission(int taskId);
        //例如GetAll方法
        //  Task<ListResultDto<RQAfficheDto>> GetAllCargoInfo(RQAfficheDto input);
       IList<InvoiceInfoDto> GetAllMissions();

        //BranchInfoDto GetTruckInfoes(BranchInfoDto input);//根据查询参数 获取结果列表
        PagedResultDto<InvoiceInfoDto> GetPagedRQAfficheInfos(SearchInvoiceInput input);//根据查询参数，返回被分页的结果列表


        InvoiceInfoDto GetMissionById(uint taskId);
        //TaskCacheItem GetTaskFromCacheById(int taskId);
        // Task<RQAfficheDto> GetMissionByIdAsync(int taskId);
    }
}
