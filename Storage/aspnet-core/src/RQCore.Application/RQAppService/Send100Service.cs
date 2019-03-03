using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RQCore.RQDtos;
using RQCore.RQEnitity;
using Abp.Extensions;
using RQCore.IRQAppService;
using System.Collections;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace RQCore.RQAppService
{
   public class Send100Service : RQCoreAppServiceBase
    {
       
        public string Get(string com, string strl)
        {
          
            var task = Send100.Instance().Get(com, strl);
            return task;
        }


       
    }
}
