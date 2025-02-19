using Microsoft.EntityFrameworkCore;
using PermissionsAPI.Domain.Entities;

namespace PermissionsAPI.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}