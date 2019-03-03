using System.Text;
using System.Threading.Tasks;
using System.Linq;
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
using System.Collections.Generic;

namespace RQCore.RQAppService
{
    public class DgDictionaryService : RQCoreAppServiceBase, IDgDictionaryService
    {

        private readonly IRepository<DgDictionary, int> _DgDictionaryRepository;
        private readonly DgDictionaryManager _DgDictManager;
        public DgDictionaryService(IRepository<DgDictionary, int> DgDictionaryRepository, DgDictionaryManager DgDictManager)
        {
            _DgDictionaryRepository = DgDictionaryRepository;
            _DgDictManager = DgDictManager;
        }
        [UnitOfWork]
        public DgDictOutput CreateMission(DgDictInput input)
        {
            var task = Mapper.Map<DgDictionary>(input);
            task.Id = null;
            if (task != null)
            { var result = _DgDictionaryRepository.Insert(task); }

            var DGresult = Mapper.Map<DgDictOutput>(task);

            CurrentUnitOfWork.SaveChanges();
            return DGresult;
        }

        public int DeleteMission(int taskid)
        {
            var task = _DgDictionaryRepository.FirstOrDefault(t => t.Id == taskid);
            if (task != null)
            {
                _DgDictionaryRepository.Delete(t => t.Id == taskid);
               
            }
            return taskid;

        }

        public IList<DgDictOutput> GetAllMission()
        {
            var task = _DgDictionaryRepository.GetAll()
                .OrderBy(t => t.Subject)
                .OrderBy(t => t.Sorting)
                .OrderBy(t => t.CreationTime)
                .ToList();
            var result = Mapper.Map<List<DgDictOutput>>(task);
            return result;
        }

        public DgDictOutput GetMissionById(int taskId)
        {
            var task = _DgDictionaryRepository.FirstOrDefault(t => t.Id == taskId);
            var result = Mapper.Map<DgDictOutput>(task);
            return result;
        }

        public DgDictOutput UpdtaeMission(DgDictInput input)
        {
            var task = Mapper.Map<DgDictionary>(input);
            _DgDictionaryRepository.Update(task);
            var result = Mapper.Map<DgDictOutput>(task);
            return result;
        }
        //public bool isDisplay { get; set; }

        public string UpdateIssisplay(int[] taskIdlist_True,int [] taskIdlist_False)
        {
            try
            {
                foreach (int taskId in taskIdlist_True)
                {
                    var task = _DgDictionaryRepository.FirstOrDefault(t => t.Id == taskId);
                    task.isDisplay = true;
                    _DgDictionaryRepository.Update(task);

                }


                foreach (int taskId in taskIdlist_False)
                {
                    var task = _DgDictionaryRepository.FirstOrDefault(t => t.Id == taskId);
                    task.isDisplay = false;
                    _DgDictionaryRepository.Update(task);
                }

                return "成功";
            }
            catch
            {
                return "失败";
            }
        }

        /// <summary>
        /// 下拉框接口 系统设置里面
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        public IList<DgDictSelect> GetSelectList(string taskid)
        {
            var task = _DgDictManager.GetSelectList(taskid);
            return task;
        }

    }
}
