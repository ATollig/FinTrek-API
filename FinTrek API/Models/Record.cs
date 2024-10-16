namespace FinTrek_API.Models
{
    public class Record
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; }
        public double Amount {  get; set; }
        public string? Note { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public int RecordTypeId { get; set; }
        public RecordType RecordType { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PayerId { get; set; }
        public Payer Payer { get; set; }
        public int PayeeId { get; set; }
        public Payee Payee { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int CurrencyCodeId { get; set; }
        public CurrencyCode CurrencyCode { get; set; }

        public ICollection<AccountRecord> AccountRecords { get; set; }
    }
}
