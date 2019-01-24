using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RQCore.RQDtos;

namespace RQCore.IRQAppService
{
    public interface IT_ExpressTypeAppService:IApplicationService
    {
        IList<SelectStringDto> GetAllMession();
        PagedResultDto<SearchT_ExpressTypeDto> GetPagedT_ExpressTypes(SearchT_ExpressTypeInput input);
        string UpdateMission(dynamic obj);
    }
}
