using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RQCore.RQDtos;

namespace RQCore.IRQAppService
{

    public interface IDgDictionaryService : IApplicationService
    {

        DgDictOutput CreateMission(DgDictInput input);
        DgDictOutput UpdtaeMission(DgDictInput input);
        int DeleteMission(int taskid);

        IList<DgDictOutput> GetAllMission();
        DgDictOutput GetMissionById(int taskId);


    }
}
