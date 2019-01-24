﻿using Abp.Application.Services.Dto;
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
    [AutoMap(typeof(DepartmentInfo))]
    public class DepartmentInfoDto : EntityDto
    {
        
        public int DepartmentID { get; set; }

        [MaxLength(255)]
        public string DepartmentName { get; set; }
    }

}
