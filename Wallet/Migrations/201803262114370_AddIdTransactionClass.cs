namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdTransactionClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Categories_Id", "dbo.Categories");
            DropForeignKey("dbo.Transactions", "Subcategories_Id", "dbo.Subcategories");
            DropForeignKey("dbo.Transactions", "WalletAndBanks_Id", "dbo.WalletAndBanks");
            DropIndex("dbo.Transactions", new[] { "Categories_Id" });
            DropIndex("dbo.Transactions", new[] { "Subcategories_Id" });
            DropIndex("dbo.Transactions", new[] { "WalletAndBanks_Id" });
            RenameColumn(table: "dbo.Transactions", name: "Categories_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Transactions", name: "Subcategories_Id", newName: "SubcategoryId");
            RenameColumn(table: "dbo.Transactions", name: "WalletAndBanks_Id", newName: "WalletAndBankId");
            AlterColumn("dbo.Transactions", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "SubcategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "WalletAndBankId", c => c.Int(nullable: true));
            CreateIndex("dbo.Transactions", "CategoryId");
            CreateIndex("dbo.Transactions", "SubcategoryId");
            CreateIndex("dbo.Transactions", "WalletAndBankId");
            AddForeignKey("dbo.Transactions", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "SubcategoryId", "dbo.Subcategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "WalletAndBankId", "dbo.WalletAndBanks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "WalletAndBankId", "dbo.WalletAndBanks");
            DropForeignKey("dbo.Transactions", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Transactions", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "WalletAndBankId" });
            DropIndex("dbo.Transactions", new[] { "SubcategoryId" });
            DropIndex("dbo.Transactions", new[] { "CategoryId" });
            AlterColumn("dbo.Transactions", "WalletAndBankId", c => c.Int());
            AlterColumn("dbo.Transactions", "SubcategoryId", c => c.Int());
            AlterColumn("dbo.Transactions", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "WalletAndBankId", newName: "WalletAndBanks_Id");
            RenameColumn(table: "dbo.Transactions", name: "SubcategoryId", newName: "Subcategories_Id");
            RenameColumn(table: "dbo.Transactions", name: "CategoryId", newName: "Categories_Id");
            CreateIndex("dbo.Transactions", "WalletAndBanks_Id");
            CreateIndex("dbo.Transactions", "Subcategories_Id");
            CreateIndex("dbo.Transactions", "Categories_Id");
            AddForeignKey("dbo.Transactions", "WalletAndBanks_Id", "dbo.WalletAndBanks", "Id");
            AddForeignKey("dbo.Transactions", "Subcategories_Id", "dbo.Subcategories", "Id");
            AddForeignKey("dbo.Transactions", "Categories_Id", "dbo.Categories", "Id");
        }
    }
}
