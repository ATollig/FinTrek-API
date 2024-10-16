namespace FinTrek_API.Models
{
    public class AccountRecord
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int RecordId { get; set; }
        public Record Record { get; set; }

        public bool IsTransfer { get; set; } // The extra attribute to check if it's a transfer
    }
}
