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

namespace RQCore.RQAppService
{
    public class ExpressService : IExpressAppService
    {
        private readonly IRepository<Express, int> _ExpressRepository;
        public ExpressService (IRepository<Express, int> ExpressRepository)
        {
            _ExpressRepository = ExpressRepository;
        }

        public IList<SelectStringDto> GetExpresslist()
        {
            var task = (from r in _ExpressRepository.GetAll()
                        select new SelectStringDto
                        {
                            Id = r.Province,
                            Name = r.Province
                        }).Distinct().ToList();
            return task;
        }

        public SearchExpressOut GetExpressOut(SearchExpressInput input)
        {
           
            if(input.Kg<3)
            {
                var task = _ExpressRepository.FirstOrDefault(t => t.Province == input.Province && t.Type=="标准快递");
                var result = Mapper.Map<SearchExpressOut>(task);
                result.Price = task.Price_Kg + task.Price_Kg_One * (input.Kg - 1);  //首重1KG，
                return result;
            }
            else
            {
                var task = _ExpressRepository.FirstOrDefault(t => t.Province == input.Province && t.Type=="优惠快递");
                var result = Mapper.Map<SearchExpressOut>(task);
                result.Price = task.Price_Kg + task.Price_Kg_One * (input.Kg - 3);  //首重3KG
                return result;

            }

        }

    }
}
