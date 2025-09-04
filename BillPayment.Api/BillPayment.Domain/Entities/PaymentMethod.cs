namespace BillPayment.Domain.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
