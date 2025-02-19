using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionsAPI.Domain.Entities;

namespace PermissionsAPI.Infrastructure.Persistence.Configurations
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Description).IsRequired().HasMaxLength(50);
        }
    }
}