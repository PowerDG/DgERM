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
    [AutoMap(typeof(RQAfficheInfo))]
    public class RQAfficheDto 
    {  
        public   int? Id { get; set; }

        public int UserID { get; set; }
        public string Claime_Type { get; set; }
        public string Super_Type { get; set; }
        public string Claim_Name { get; set; }


        public string AfficheTitle { get; set; }
        public string AfficheContent { get; set; }
        public string AfficheData { get; set; }
        public int BranchID { get; set; }
        public string TypeName { get; set; }
        public int Status { get; set; }
        public int Sorting { get; set; }
        public int pageIndex { get; set; }

        public int pageSize { get; set; }



    }


    public class SearchRQAfficheInput
    {

        public int pageIndex { get; set; }

        public int pageSize { get; set; }
        public string Claime_Type { get; set; } 
        public string Claim_Name { get; set; }


        public string AfficheTitle { get; set; }


        public int? BranchID { get; set; }

        public string BranchName { get; set; }



    }
}
