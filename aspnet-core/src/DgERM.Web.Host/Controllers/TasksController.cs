using DgERM.Controllers;
using DgERM.DgDemo.Tasks;
using DgERM.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DgERM.Web.Host.Controllers
{
    public class TasksController : DgERMControllerBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly IUserAppService _userAppService;

        //[ChildActionOnly]
        public PartialViewResult Create()
        {
            var userList = _userAppService.GetUsers();
            ViewBag.AssignedPersonId = new SelectList(userList.Items, "Id", "Name");
            return PartialView("_CreateTask");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTaskInput task)
        {
            var id = _taskAppService.CreateTask(task);

            var input = new GetTasksInput();
            var output = _taskAppService.GetTasks(input);

            return PartialView("_List", output.Tasks);
        }

        public TasksController(ITaskAppService taskAppService, IUserAppService userAppService)
        {
            _taskAppService = taskAppService;
            _userAppService = userAppService;
        }

        public PartialViewResult RemoteCreate()
        {
            var userList = _userAppService.GetUsers();
            ViewBag.AssignedPersonId = new SelectList(userList.Items, "Id", "Name");
            return PartialView("_CreateTaskPartial");
        }

        [ChildActionOnly]
        public PartialViewResult Create()
        {
            var userList = _userAppService.GetUsers();
            ViewBag.AssignedPersonId = new SelectList(userList.Items, "Id", "Name");
            return PartialView("_CreateTask");
        }
    }
}
