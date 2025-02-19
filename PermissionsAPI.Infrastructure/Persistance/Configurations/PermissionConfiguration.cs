using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionsAPI.Domain.Entities;

namespace PermissionsAPI.Infrastructure.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.PermissionType)
                .WithMany()
                .HasForeignKey(p => p.PermissionTypeId);
        }
    }
}