using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FinTrek_API.Models
{
    public class FinTrekDBContext : IdentityDbContext<ApplicationUser>
    {
        public FinTrekDBContext(DbContextOptions<FinTrekDBContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CurrencyCode> CurrencyCodes { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<Payer> Payers { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<RecordType> RecordTypes { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }
        public DbSet<AccountRecord> AccountRecords { get; set; }             
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

            modelBuilder.Entity<Category>()
                .HasOne(sp => sp.RecordType)
                .WithMany()
                .HasForeignKey(sp => sp.RecordTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasOne(sp => sp.ApplicationUser)
                .WithMany()
                .HasForeignKey(sp => sp.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasOne(sp => sp.Parent)
                .WithMany()
                .HasForeignKey(sp => sp.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Budget>()
                .HasOne(sp => sp.Category)
                .WithMany()
                .HasForeignKey(sp => sp.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Budget>()
                .HasOne(sp => sp.ApplicationUser)
                .WithMany()
                .HasForeignKey(sp => sp.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Saving>()
                .HasOne(sp => sp.Category)
                .WithMany()
                .HasForeignKey(sp => sp.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Record>()
                .HasOne(sp => sp.PaymentType)
                .WithMany()
                .HasForeignKey(sp => sp.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Record>()
                .HasOne(sp => sp.RecordType)
                .WithMany()
                .HasForeignKey(sp => sp.RecordTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Record>()
                .HasOne(sp => sp.Category)
                .WithMany()
                .HasForeignKey(sp => sp.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Record>()
                .HasOne(sp => sp.Payer)
                .WithMany()
                .HasForeignKey(sp => sp.PayerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Record>()
                .HasOne(sp => sp.Payee)
                .WithMany()
                .HasForeignKey(sp => sp.PayeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Record>()
                .HasOne(sp => sp.ApplicationUser)
                .WithMany()
                .HasForeignKey(sp => sp.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Record>()
                .HasOne(sp => sp.CurrencyCode)
                .WithMany()
                .HasForeignKey(sp => sp.CurrencyCodeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SavingRecord>()
                .HasOne(sp => sp.Record)
                .WithMany()
                .HasForeignKey(sp => sp.RecordId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SavingRecord>()
                .HasOne(sp => sp.Saving)
                .WithMany()
                .HasForeignKey(sp => sp.SavingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccountRecord>()
                .HasKey(ar => new { ar.AccountId, ar.RecordId });

            modelBuilder.Entity<AccountRecord>()
                .HasOne(ar => ar.Account)
                .WithMany(a => a.AccountRecords)
                .HasForeignKey(ar => ar.AccountId);

            modelBuilder.Entity<AccountRecord>()
                .HasOne(ar => ar.Record)
                .WithMany(r => r.AccountRecords)
                .HasForeignKey(ar => ar.RecordId);


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
