using Microsoft.AspNetCore.Identity;

namespace FinTrek_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty; 
        public string Surname { get; set; } = string.Empty;
        public int? SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }
        public int? CurrencyCodeId { get; set; }
        public CurrencyCode CurrencyCode { get; set; }

    }
}
