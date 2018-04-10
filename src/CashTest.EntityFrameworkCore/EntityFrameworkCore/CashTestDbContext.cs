using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CashTest.Authorization.Roles;
using CashTest.Authorization.Users;
using CashTest.Entities;
using CashTest.MultiTenancy;

namespace CashTest.EntityFrameworkCore
{
    public class CashTestDbContext : AbpZeroDbContext<Tenant, Role, User, CashTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CashTestDbContext(DbContextOptions<CashTestDbContext> options)
            : base(options)
        {
        }

        public DbSet<Map> Maps { get; set; }
        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().HasOne(a => a.Map);
        }
    }
}
