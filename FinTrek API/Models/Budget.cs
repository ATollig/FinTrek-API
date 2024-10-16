namespace FinTrek_API.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime DateSet { get; set; }
        public int MonthlyPeriod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
