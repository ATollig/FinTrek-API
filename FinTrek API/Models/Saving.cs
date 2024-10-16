namespace FinTrek_API.Models
{
    public class Saving
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalAmount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public bool GoalReached { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
