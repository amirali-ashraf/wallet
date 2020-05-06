namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Wallet.Models.WalletModels;
    using Wallet.Models;
    using System.Collections.ObjectModel;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.Models.WalletDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentitySample.Models.WalletDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //            
            context.Categories.AddOrUpdate(c=>c.Name,
                new Category
                {
                    Name = "Bills",
                    TypeOfCategory = Category.Type.Expenditure,
                    Subcategories = new Collection<Subcategory> {
                        new Subcategory() { Name = "Water" },
                        new Subcategory() { Name = "Electricity" }
                    },                   
                },
                new Category { Name = "Car Costs", TypeOfCategory = Category.Type.Expenditure },
                new Category { Name = "Salary", TypeOfCategory = Category.Type.Income },
                new Category { Name = "Bank Interest", TypeOfCategory = Category.Type.Income },
                new Category { Name = "Foods", TypeOfCategory = Category.Type.Expenditure }                

                );
        }
    }
}
