using MediatR;

namespace PermissionsAPI.Application.Permissions.Commands
{
    public class RequestPermissionCommand : IRequest<int>
    {
        public int EmployeeId { get; set; }
        public int PermissionTypeId { get; set; }
    }
}