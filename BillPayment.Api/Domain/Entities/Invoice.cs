namespace BillPayment.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssuerIdentification { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TimelyPaymentDate { get; set; }
        public DateTime SuspensionDate { get; set; }
        public string BillingPeriod { get; set; } = string.Empty;
        public int IdUser { get; set; }
        public int IdService { get; set; }
        public int StatusInvoceId { get; set; }
        public int? PaymentId { get; set; }

        public required StatusInvoce StatusInvoce { get; set; }
        public Payment? Payment { get; set; }
        public User? User { get; set; }
        public required Service Service { get; set; }

    }
}
