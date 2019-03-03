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
    [AutoMap(typeof(Express))]
    public class ExpressDto
    {   public int? Id { get; set; }
        public string Type { get; set; }
        public string Province { get; set; }
        public int Price_Kg { get; set; }
        public int Price_Kg_One { get; set; }
        public string Aging { get; set; }
    }
    [AutoMap(typeof(Express))]
    public class SearchExpressOut
    {
        public string Province { get; set; }
        public decimal Price { get; set; }    
        public string Aging { get; set; }
    }
    [AutoMap(typeof(Express))]
    public class SearchExpressInput
    {
        public string Province { get; set; }
        public decimal Kg { get; set; }

    }
    [AutoMap(typeof(Express))]
    public class ExpressExeclOut
    {
       
        public string Type { get; set; }
        public string Province { get; set; }
        public int Price_Kg { get; set; }
        public int Price_Kg_One { get; set; }
        public string Aging { get; set; }
    }
}
