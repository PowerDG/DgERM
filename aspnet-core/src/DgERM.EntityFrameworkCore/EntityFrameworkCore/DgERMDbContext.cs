using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DgERM.Authorization.Roles;
using DgERM.Authorization.Users;
using DgERM.MultiTenancy;

namespace DgERM.EntityFrameworkCore
{
    public class DgERMDbContext : AbpZeroDbContext<Tenant, Role, User, DgERMDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DgERMDbContext(DbContextOptions<DgERMDbContext> options)
            : base(options)
        {
        }
    }
}
