using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinTrek_API.Models
{
    public class SubscriptionPayment
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatePaid { get; set; }
        public double Amount { get; set; }
        public DateTime ValidUntil { get; set; }

        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; } = null!; // Non-nullable initialization

        public string ApplicationUserId { get; set; } = string.Empty; // Initialize non-nullable property
        public ApplicationUser ApplicationUser { get; set; } = null!; // Non-nullable initialization
    }

}
