using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RQCore.RQDtos;

namespace RQCore.IRQAppService
{
    public interface IInvoiceItemService : IApplicationService
    {

        void CreateMission(InvoiceItemInput input);
        int? CreateMissionQ(InvoiceItemInput input);

        void UpdateMission(InvoiceItemInput input);


        void DeleteMission(uint taskId);
        //例如GetAll方法
        //  Task<ListResultDto<RQAfficheDto>> GetAllCargoInfo(RQAfficheDto input);
       IList<InvoiceItemDto> GetAllMissions(uint taskId);

        //BranchInfoDto GetTruckInfoes(BranchInfoDto input);//根据查询参数 获取结果列表
        PagedResultDto<InvoiceItemDto> GetPagedRQAfficheInfos(SearchInvoiceItemInput input);//根据查询参数，返回被分页的结果列表


        InvoiceItemDto GetMissionById(uint taskId);
        //TaskCacheItem GetTaskFromCacheById(int taskId);
        // Task<RQAfficheDto> GetMissionByIdAsync(int taskId);
    }
}
