namespace BillPayment.Domain.Entities
{
    public class StatusInvoce: DomainEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
