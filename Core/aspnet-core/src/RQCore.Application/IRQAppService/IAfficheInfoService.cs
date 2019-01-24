using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RQCore.RQDtos;

namespace RQCore.IRQAppService
{
    public interface IAfficheInfoService : IApplicationService
    {

        void CreateMission(RQAfficheDto input);
        int? CreateMissionQ(RQAfficheDto input);

        void UpdateMission(RQAfficheDto input);


        void DeleteMission(int taskId);
        //例如GetAll方法
        //  Task<ListResultDto<RQAfficheDto>> GetAllCargoInfo(RQAfficheDto input);
       IList<RQAfficheDto> GetAllMissions();

        //BranchInfoDto GetTruckInfoes(BranchInfoDto input);//根据查询参数 获取结果列表
        PagedResultDto<RQAfficheDto> GetPagedRQAfficheInfos(SearchRQAfficheInput input);//根据查询参数，返回被分页的结果列表


        RQAfficheDto GetMissionById(int taskId);
        //TaskCacheItem GetTaskFromCacheById(int taskId);
        // Task<RQAfficheDto> GetMissionByIdAsync(int taskId);
    }
}
