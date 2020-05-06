using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Wallet.Models.WalletModels;

namespace IdentitySample.Models
{
    public class WalletDbContext : IdentityDbContext<ApplicationUser>
    {
        public WalletDbContext()
            : base("name = WalletDB", throwIfV1Schema: false)
        {
        }

        //todo: disable casecade delete for the bank and wallet
        //newly added database's tables

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<WalletAndBank> WalletAndBanks { get; set; }

        static WalletDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<WalletDbContext>(new ApplicationDbInitializer());
        }

        public static WalletDbContext Create()
        {
            return new WalletDbContext();
        }
    }
}