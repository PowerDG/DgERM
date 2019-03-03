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
    public class PluService : RQCoreAppServiceBase, IPluAppService
    {
        private readonly IRepository<Plu, int> _Plurepository;
        public PluService(IRepository<Plu,int> Plurepository)
        {
            _Plurepository = Plurepository;
        }


        //public IList<PluDto> GetAllMissions()
        //{
        //    var task = _Plurepository.GetAll().ToList();
        //    var result = Mapper.Map<List<PluDto>>(task);
        //    return result;
        //}
        public List<SelectStringDto> GetProvince()   //省份
        {
            var task = (from t in _Plurepository.GetAll()
                        select new SelectStringDto
                        { Id = t.Province, Name = t.Province }).Distinct().ToList();

            return task;
        }
        public List<SelectStringDto> GetCity(string taskId)   //根据省份筛选城市
        {
            var task = (from t in _Plurepository.GetAll()
                        where t.Province == taskId
                        select new SelectStringDto
                        { Id = t.Destination_city, Name = t.Destination_city }).Distinct().ToList();

            return task;
        }

        public List<SelectStringDto> GetAllCity()   //列出所有城市
        {
            var task = (from t in _Plurepository.GetAll()                      
                        select new SelectStringDto
                        { Id = t.Destination_city, Name = t.Destination_city }).Distinct().ToList();

            return task;
        }

        public SearchPluDtoOutput GetPlu(SearchPluDtoInput input)  //查价
        {
            var task = _Plurepository.GetAll()
                 .FirstOrDefault(t => t.Province == input.Province && t.Destination_city == input.Destination_city);
            var result = Mapper.Map<SearchPluDtoOutput>(task);
            var Price_Kg = task.Price_Kg * input.Total_Kg;
            var Price_Cu = task.Price_Cu * input.Total_Cu;
            if(Price_Kg>=Price_Cu)
            {
                result.Price = Price_Kg;
            }
            else
            {
                result.Price = Price_Cu;
            }
           
            return result;
        }

        public SearchPluDtoOutput GetPlu_Express(SearchPluDtoInput input)  //查价 快递
        {
            var task = _Plurepository
                 .FirstOrDefault(t => t.Province == input.Province );
            var result = Mapper.Map<SearchPluDtoOutput>(task);
            var Price_Kg = task.Price_Kg * input.Total_Kg;
        

                result.Price = Price_Kg;


            return result;
        }

        public void CreatePlu(PluDto input)
        {
            var task = Mapper.Map<Plu>(input);
            _Plurepository.Insert(task);
        }

        public void Delete(string tasskId)
        {
           _Plurepository.Delete(x=> x.Province==tasskId);
       
        }
    }
}
