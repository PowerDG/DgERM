using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RQCore.RQDtos;


namespace RQCore.IRQAppService
{ 
    public interface IInspectionAppService : IApplicationService
    {

        PagedResultDto<SearchInspectionDto> GetAllInspection(SearchInspectionInput SearchInput);   

        InspectionDto GetInspection(InspectionDto input);

        InspectionDto CreateInspection(InspectionDto input);
        int GetCount(long userId);
        PagedResultDto<SearchInspectionDto> GetAllInspectionBySelf(SearchInspectionInput input);
    }
}
