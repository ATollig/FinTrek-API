using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinTrek_API.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; } = string.Empty;

        [Required] 
        public string Features { get; set; } = string.Empty;

        
        public double MonthlyPrice { get; set; }  // Explicitly defining precision and scale

       
        public double YearlyPrice { get; set; }  // Explicitly defining precision and scale
    }
}
