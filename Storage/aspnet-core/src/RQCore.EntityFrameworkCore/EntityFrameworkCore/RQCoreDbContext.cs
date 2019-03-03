using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using RQCore.Authorization.Roles;
using RQCore.Authorization.Users;
using RQCore.MultiTenancy;
using RQCore.RQEnitity;

namespace RQCore.EntityFrameworkCore
{
    public class RQCoreDbContext : AbpZeroDbContext<Tenant, Role, User, RQCoreDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<TruckInfo> TruckInfos { get; set; }

        public DbSet<TruckModel> TruckModels { get; set; }

        public DbSet<BranchInfo> BranchInfos { get; set; }

        public DbSet<CargoInfo> CargoInfos { get; set; }
        public DbSet<CargoVector> CargoVectors { get; set; }
        public DbSet<BillInfo> BillInfos { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DbSet<DepartmentInfo> DepartmentInfos { get; set; }
        public DbSet<T_GoodsImg> T_GoodsImgs { get; set; }
        public DbSet<Plu> Plus { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<LogisticsInfo> LogisticsInfos { get; set; }
        public DbSet<StateInfo> StateInfos { get; set; }
        public DbSet<T_ExpressType> T_ExpressTypes { get; set; }
        public DbSet<DgDictionary> DgDictionarys { get; set; }

        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public DbSet<InvoiceInfo> InvoiceInfoes { get; set; }

        public DbSet<RQAfficheInfo> RQAfficheInfoes { get; set; }

        public DbSet<Express> Expresss { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public RQCoreDbContext(DbContextOptions<RQCoreDbContext> options)
            : base(options)
        {
        }
    }
}
