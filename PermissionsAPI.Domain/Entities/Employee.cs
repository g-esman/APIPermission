namespace PermissionsAPI.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}