namespace BillPayment.Domain.Entities
{
    public class Service: DomainEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
