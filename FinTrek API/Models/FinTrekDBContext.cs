using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinTrek_API.Models
{
    public class FinTrekDBContext : IdentityDbContext<ApplicationUser>
    {
        public FinTrekDBContext(DbContextOptions<FinTrekDBContext> options) : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<Payer> Payers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call the base method

            modelBuilder.Entity<SubscriptionPayment>()
                .HasOne(sp => sp.Subscription)
                .WithMany()
                .HasForeignKey(sp => sp.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubscriptionPayment>()
                .HasOne(sp => sp.ApplicationUser)
                .WithMany()
                .HasForeignKey(sp => sp.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                  .HasOne(sp => sp.AccountType)
                  .WithMany()
                  .HasForeignKey(sp => sp.AccountTypeId)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(sp => sp.Bank)
                .WithMany()
                .HasForeignKey(sp => sp.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(sp => sp.ApplicationUser)
                .WithMany()
                .HasForeignKey(sp => sp.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed roles
            SeedRoles(modelBuilder);

            // Seed subscriptions
            SeedSubscriptions(modelBuilder);

            // Seed users
            SeedUsers(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            var roles = new[]
            {
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Dev", NormalizedName = "DEV" },
                new IdentityRole { Id = "3", Name = "Pro", NormalizedName = "PRO" },
                new IdentityRole { Id = "4", Name = "Advanced", NormalizedName = "ADVANCED" },
                new IdentityRole { Id = "5", Name = "Beginner", NormalizedName = "BEGINNER" },
                new IdentityRole { Id = "6", Name = "Free", NormalizedName = "FREE" }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

        private void SeedSubscriptions(ModelBuilder modelBuilder)
        {
            var subscriptions = new[]
            {
                new Subscription { Id = 1, Name = "Free", Features = "Limited access", MonthlyPrice = 0.00, YearlyPrice = 0.00 },  
                new Subscription { Id = 2, Name = "Beginner", Features = "Basic access", MonthlyPrice = 9.99, YearlyPrice = 99.99 },
                new Subscription { Id = 3, Name = "Advanced", Features = "Advanced features", MonthlyPrice = 29.99, YearlyPrice = 299.99 },
                new Subscription { Id = 4, Name = "Pro", Features = "Full features", MonthlyPrice = 59.99, YearlyPrice = 599.99 },
            };

            modelBuilder.Entity<Subscription>().HasData(subscriptions);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                Name = "Admin",
                Surname = "User",
                EmailConfirmed = true
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            var devUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "dev@example.com",
                NormalizedUserName = "DEV@EXAMPLE.COM",
                Email = "dev@example.com",
                NormalizedEmail = "DEV@EXAMPLE.COM",
                Name = "Dev",
                Surname = "User",
                EmailConfirmed = true
            };
            devUser.PasswordHash = hasher.HashPassword(devUser, "Dev@123");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser, devUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "1" },
                new IdentityUserRole<string> { UserId = devUser.Id, RoleId = "2" }
            );
        }
    }
}
