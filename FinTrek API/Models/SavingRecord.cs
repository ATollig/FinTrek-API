namespace FinTrek_API.Models
{
    public class SavingRecord
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public bool Claim {  get; set; }
        public int SavingId { get; set; }
        public Saving Saving { get; set; }
        public int RecordId { get; set; }
        public Record Record { get; set; }
    }
}
