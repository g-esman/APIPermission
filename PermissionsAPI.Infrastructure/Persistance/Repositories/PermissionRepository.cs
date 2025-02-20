using Microsoft.EntityFrameworkCore;
using PermissionsAPI.Domain.Entities;
using PermissionsAPI.Infrastructure.Persistence;

namespace PermissionsAPI.Infrastructure.Persistence.Repositories
{
    public class PermissionRepository : IRepository<Permission>
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Permission?> GetByIdAsync(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task AddAsync(Permission permission)
        {
            await _context.Permissions.AddAsync(permission);
        }

        public async Task UpdateAsync(Permission permission)
        {
            await Task.Run(() => _context.Permissions.Update(permission));
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
