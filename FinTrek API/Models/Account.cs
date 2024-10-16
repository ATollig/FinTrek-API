namespace FinTrek_API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public double StartingBalance { get; set; }
        public int StartingDate { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }

        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }

        public ICollection<AccountRecord> AccountRecords { get; set; }
    }
}
