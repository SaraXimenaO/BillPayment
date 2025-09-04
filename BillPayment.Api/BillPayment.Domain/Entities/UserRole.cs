namespace BillPayment.Domain.Entities
{
    public class UserRole: DomainEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
