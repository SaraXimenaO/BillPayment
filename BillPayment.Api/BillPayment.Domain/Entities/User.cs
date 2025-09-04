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
        public required UserRole UserRole { get; set; }
    }
}
