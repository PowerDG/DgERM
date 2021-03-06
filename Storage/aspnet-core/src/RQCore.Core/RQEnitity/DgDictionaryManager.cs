﻿using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using RQCore.RQEnitity;


namespace RQCore.RQEnitity
{
    public class DgDictionaryManager : DomainService
    {
        private readonly IRepository<DgDictionary, int> _DgDictionaryRepository;
        public DgDictionaryManager(IRepository<DgDictionary, int> DgDictionaryRepository)
        {
            _DgDictionaryRepository = DgDictionaryRepository;
        }

        public IList<DgDictSelect> GetSelectList(string taskid)
        {
            var task = (from r in _DgDictionaryRepository.GetAll()
                        where (r.Claim_Type == taskid)
                        select new DgDictSelect
                        {
                            Claim_Name = r.Claim_Name,
                            DisplayName = r.DisplayName
                        }).ToList();
            return task;
        }
    }
}
