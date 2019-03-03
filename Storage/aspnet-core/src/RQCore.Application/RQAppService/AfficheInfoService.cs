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
using Abp.Domain.Uow;

namespace RQCore.RQAppService
{
    public class AfficheInfoService : RQCoreAppServiceBase, IAfficheInfoService
    {


        private readonly IRepository<RQAfficheInfo, int> _AfficheRepository;
        public AfficheInfoService(IRepository<RQAfficheInfo, int> afficheRepository)
        {
            _AfficheRepository = afficheRepository;
        }
        public void CreateMission(RQAfficheDto input)
        {
            var task = Mapper.Map<RQAfficheInfo>(input);
            task.Id = null;
            //if (task != null)
            //{ var result = _AfficheRepository.Insert(task); }

            _AfficheRepository.Insert(task);
        }
        [UnitOfWork]
        public int? CreateMissionQ(RQAfficheDto input)
        {
            var task = Mapper.Map<RQAfficheInfo>(input);
            task.Id = null;
            if (task != null)
            {
                var result = _AfficheRepository.Insert(task);
                CurrentUnitOfWork.SaveChanges();

                return result.Id;
            }
            else
            { return 0; }
        }
        public void UpdateMission(RQAfficheDto input)
        {
            // var task = _AfficheRepository.GetAll().FirstOrDefault(t => t.CargoID == input.CargoID);
            var result = Mapper.Map<RQAfficheInfo>(input);
            result.Id = null;
            if (result != null)
            { _AfficheRepository.Update(result); }

        }
        public void DeleteMission(int taskId)
        {
            var task = _AfficheRepository.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            { _AfficheRepository.Delete(task); }
        }
        public PagedResultDto<RQAfficheDto> GetPagedRQAfficheInfos(SearchRQAfficheInput input)
        {
            //初步过滤
            var query = _AfficheRepository.GetAll().OrderByDescending(t => t.CreationTime).ToList();
            //.WhereIf(input.BranchID.HasValue, t => t.BranchID == input.BranchID.Value)
            //.WhereIf(!input.CargoName.IsNullOrEmpty(), t => t.CargoName.Contains(input.CargoName));
            //排序
            //query = !string.IsNullOrEmpty(input.Sorting) ? query.OrderBy(input.Sorting) : query.OrderByDescending(t => t.CreationTime);
           // query= query.ToList();
            //获取总数
            var tasksCount = query.Count;
            //默认的分页方式 source.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var taskList = query.Skip((input.pageIndex - 1) * input.pageSize).Take(input.pageSize).ToList();
            //ABP提供了扩展方法PageBy分页方式
            //var taskList = query.PageBy(input).ToList(); 
            return new PagedResultDto<RQAfficheDto>(tasksCount, taskList.MapTo<List<RQAfficheDto>>());
        }



        public IList<RQAfficheDto> GetAllMissions()
        {
            var task = _AfficheRepository.GetAll().OrderByDescending(t => t.Id).ToList();
            return Mapper.Map<List<RQAfficheDto>>(task);
        }

        //public async Task<ListResultDto<RQAfficheDto>> GetAllRQAfficheInfo(RQAfficheDto input)
        //{
        //    var task = await _AfficheRepository.GetAll().OrderByDescending(t => t.CargoID).ToListAsync();
        //    return new ListResultDto<RQAfficheDto>(
        //       AutoMapper.Mapper.Map<List<RQAfficheDto>>(task));
        //}

        public RQAfficheDto GetMissionById(int taskId)
        {
            var task = _AfficheRepository.FirstOrDefault(t => t.Id == taskId);
            var result = Mapper.Map<RQAfficheDto>(task);
            //if (task != null)
            //{ return result; }
            //else
            //{ //throw new NotImplementedException();
            //}
            return result;
        }



    }
}
