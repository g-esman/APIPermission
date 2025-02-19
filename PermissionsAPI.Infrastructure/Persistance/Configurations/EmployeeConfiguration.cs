using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionsAPI.Domain.Entities;

namespace PermissionsAPI.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(30);

            builder.HasMany(e => e.Permissions)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId);
        }
    }
}