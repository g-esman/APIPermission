using MediatR;
using PermissionsAPI.Domain.Entities;
using PermissionsAPI.Infrastructure.Persistence;

namespace PermissionsAPI.Application.Permissions.Commands
{
    public class RequestPermissionHandler : IRequestHandler<RequestPermissionCommand, int>
    {
        private readonly AppDbContext _context;

        public RequestPermissionHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = new Permission
            {
                EmployeeId = request.EmployeeId,
                PermissionTypeId = request.PermissionTypeId
            };

            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync(cancellationToken);

            return permission.Id;
        }
    }
}