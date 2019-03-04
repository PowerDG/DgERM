﻿using Abp.Application.Services;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace DgERM.DgDemo
{
    public class TaskAppService : ApplicationService
    {
        public IEventBus EventBus { get; set; }

        public TaskAppService()
        {
            EventBus = NullEventBus.Instance;
        }


        //在注入事件总线上，属性注入比构造器注入更合适。
        //    你的类可以没有事件总线，NullEventBus实现了空对象模式，
        //    当你调用它的方法时，方法里什么也不做。
        public void CompleteTask(CompleteTaskInput input)
        {
            //TODO: complete the task on database...
            EventBus.Trigger(new TaskCompletedEventData { TaskId = 42 });
            EventBus.Register<TaskCompletedEventData>(eventData =>
            {
                WriteActivity("A task is completed by id = " + eventData.TaskId);
            });



            //“任务完成”事件发生后，这个lambda方法就会被调用。
            //第二个是接受一个实现了IEventHantler<T> 的对象：
            EventBus.Register<TaskCompletedEventData>(new ActivityWriter());
             

            //同样是为事件调用ActivityWriter实例。第三个重载接受两个泛型参数：
            EventBus.Register<TaskCompletedEventData, ActivityWriter>();


        }

        private void WriteActivity(string v)
        {
            throw new NotImplementedException();
        }

        //触发事件的另一个方法是：
        //    使用AggregateRoot类的DomainEvents集合（查看实体文档的相关小节）。
        //    http://www.cnblogs.com/kid1412/p/5992443.html
    }


     


}
