using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RQCore.RQDtos;

namespace RQCore.IRQAppService
{
    public interface IExpressAppService: IApplicationService
    {
        SearchExpressOut GetExpressOut(SearchExpressInput input);
        IList<SelectStringDto> GetExpresslist();
    }
}
