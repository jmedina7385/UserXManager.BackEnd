using System.Collections.Generic;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.Property(c => c.Description).IsRequired().HasMaxLength(50);

            builder.HasData(new List<PermissionType>
            {
                new PermissionType
                {
                    Id = 1,
                    Description = "In Service"
                },
                new PermissionType
                {
                    Id = 2,
                    Description = "On Leave"
                },
                new PermissionType
                {
                    Id = 3,
                    Description = "On Vacation"
                },
                new PermissionType
                {
                    Id = 4,
                    Description = "On Leave"
                }
            });
        }
    }
}