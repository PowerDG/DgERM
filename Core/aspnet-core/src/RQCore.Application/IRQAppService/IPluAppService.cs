using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RQCore.RQDtos;

namespace RQCore.IRQAppService
{
  
    public interface IPluAppService : IApplicationService
    {
        //  IList<PluDto> GetAllMissions();

        List<SelectStringDto> GetProvince();  //省份选择
        List<SelectStringDto> GetCity(string taskId);    //城市选择

        List<SelectStringDto> GetAllCity();  //所有城市列表

        SearchPluDtoOutput GetPlu(SearchPluDtoInput input);
        SearchPluDtoOutput GetPlu_Express(SearchPluDtoInput input);

        void CreatePlu(PluDto input);

    }
}
