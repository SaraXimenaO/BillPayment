namespace BillPayment.Domain.Entities
{
    public class Payment: DomainEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }

    }
}
