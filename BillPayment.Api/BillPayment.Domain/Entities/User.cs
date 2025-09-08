using Throw;

namespace BillPayment.Domain.Entities
{
    public class User: DomainEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }

        public User() { }

        public User(string name, string document, string userName, string hashedPassword, int userRoleId)
        {
            Name = name;
            Document = document;
            UserName = userName;
            PasswordHash = hashedPassword;
            UserRoleId = userRoleId;
        }

        public void validateEntity() {
            Id.Throw().ThrowIfNull("El Usuario no existe");
        }
    }
}
