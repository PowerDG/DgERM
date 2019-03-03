using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using RQCore.RQEnitity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RQCore.RQDtos
{
    [AutoMap(typeof(LogisticsInfo))]
    public class LogisticsInfoDto
    {      
        public long BillNo { get; set; }
        public int State { get; set; }
        public string FillDate { get; set; }
        public string Infomation { get; set; }

        public long? CreatorUserId { get; set; }
        public DateTimeOffset CreationTime { get; set; }
    }

    public class SearchLogisticsInfoInput
    {
        public long BillNo { get; set; }
    }

    public class SearchLogisticsInfoDto
    {
        public string Time { get; set; }    
        public string Context { get; set; }
    }




}
