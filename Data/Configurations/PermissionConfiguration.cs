using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(c => c.EmployeeName).IsRequired().HasMaxLength(25);
            builder.Property(c => c.EmployeeLastName).IsRequired().HasMaxLength(25);
        }
    }
}