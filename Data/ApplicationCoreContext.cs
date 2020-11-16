using Core;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationCoreContext : DbContext
    {
        public ApplicationCoreContext(DbContextOptions<ApplicationCoreContext> options) : base(options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}