using Core;
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
    }
}