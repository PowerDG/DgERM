﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Trump.EF
     
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() 
        {
        }

        public virtual ISet<SysUser> SysUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 移除复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

 s
    }





    [Table("SysUser", Schema = "public")]
    public class SysUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
//--------------------- 
//作者：杨Zhu
//来源：CSDN
//原文：https://blog.csdn.net/asp_net_sql/article/details/80253585 
//版权声明：本文为博主原创文章，转载请附上博文链接！
}