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
    public class T_ExpressTypeDto
    {
        public string ExpressNo { get; set; }
        public string ExpressName { get; set; }
        public string ExpressICO { get; set; }
        public string Remark { get; set; }
        public bool IsDefaultShow { get; set; }
        public int Sorting { get; set; }
    }
    public class SearchT_ExpressTypeInput
    {
        public SearchT_ExpressTypeInput()
        {
            PageSize = 30;
            PageIndex = 1;
        }
            
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string ExpressName { get; set; }
        public bool? IsDefaultShow { get; set; }

    }
    public class SearchT_ExpressTypeDto
    {
        public string ExpressNo { get; set; }
        public string ExpressName { get; set; }
       // public string ExpressICO { get; set; }
        public string Remark { get; set; }
        public bool? IsDefaultShow { get; set; }
    }
    public class UpdateT_ExpressTypeInput
    {
        public string ExpressNo { get; set; }
        public int IsDefaultShow { get; set; }
    }
}
