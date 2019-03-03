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
    [AutoMap(typeof(DgDictionary))]
    public class DgDictInput : EntityDto
    {
        public string Subject { get; set; }

        public string Claim_Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Claim_Value { get; set; }

        public string Issuer { get; set; }
        public string Claim_Type { get; set; }
        public string Super_Type { get; set; }
        public string Sub_Type { get; set; }

        public int Sorting { get; set; }
        public bool isDisplay { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int? Id { get; set; }
    }


    [AutoMap(typeof(DgDictionary))]
    public class DgDictOutput : EntityDto
    {



        public bool isDisplay { get; set; }
        public string Subject { get; set; }
        public string Claim_Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Claim_Value { get; set; }

        public string Issuer { get; set; }
        public string Claim_Type { get; set; }
        public string Super_Type { get; set; }
        public string Sub_Type { get; set; }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int? Id { get; set; }
    }


}
