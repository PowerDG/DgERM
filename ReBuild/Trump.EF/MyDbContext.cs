using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trump.EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
    : base("name=YFrameContext")
        {
        }

        public virtual DbSet<SysUser> SysUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 移除复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
//--------------------- 
//作者：杨Zhu
//来源：CSDN
//原文：https://blog.csdn.net/asp_net_sql/article/details/80253585 
//版权声明：本文为博主原创文章，转载请附上博文链接！
    }
}
