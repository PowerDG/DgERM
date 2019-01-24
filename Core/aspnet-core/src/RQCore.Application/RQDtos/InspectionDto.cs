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
{    [AutoMap(typeof(Inspection))]
   public class InspectionDto
    {
        public  long? Id { get; set; }


        public long Inspection_No { get; set; }
        public string SourceType { get; set; }
        public long SourceNo { get; set; }
        public DateTime? StartDate { get; set; }
        public long DestinationNO { get; set; }
        public int Version { get; set; }
        public string ProposerName { get; set; }
        public long ProposerID { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public bool IsCandidate { get; set; }
        public int InspectionState { get; set; }
        [MaxLength(100)]
        public string InspectionName { get; set; }
        public string Action { get; set; }
        [MaxLength(255)]
        public string InspectionMemo { get; set; }
        public DateTime? EndDate { get; set; }
        public int Quality_level { get; set; }
    }

    public class SearchInspectionInput
    {
        public SearchInspectionInput()
        {
            PageIndex = 1;
            PageSize = 30;
        }
        [DefaultValue(1)]
        public int PageIndex { get; set; }
        [DefaultValue(20)]
        public int PageSize { get; set; }
        public long ProposerID { get; set; }
        public string Action_Search { get; set; }
        public string SourceType { get; set; }
        public string SourceNo { get; set; }

        public string Sorting { get; set; }
        public int? InspectionState { get; set; }
        public string InspectionName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       
    }


    [AutoMap(typeof(Inspection))]
    public class SearchInspectionDto
    {
        public long Inspection_No { get; set; }
        public string SourceType { get; set; }
        public long SourceNo { get; set; }
        public DateTime? StartDate { get; set; }
        public long DestinationNO { get; set; }
        public int Version { get; set; }
        public string ProposerName { get; set; }
      //  public long ProposerID { get; set; }
        [MaxLength(100)]
        //public string Title { get; set; }
       // public bool IsCandidate { get; set; }
        public int InspectionState { get; set; }
        [MaxLength(100)]
        public string InspectionName { get; set; }
        public string Action { get; set; }
        [MaxLength(255)]
        public string InspectionMemo { get; set; }
        public DateTime? EndDate { get; set; }
       // public int Quality_level { get; set; }
    }
}
