namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeUpdatesInDB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions", name: "Category_Id", newName: "Categories_Id");
            RenameColumn(table: "dbo.Transactions", name: "Subcategory_Id", newName: "Subcategories_Id");
            RenameColumn(table: "dbo.Transactions", name: "WalletAndBank_Id", newName: "WalletAndBanks_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_Category_Id", newName: "IX_Categories_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_Subcategory_Id", newName: "IX_Subcategories_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_WalletAndBank_Id", newName: "IX_WalletAndBanks_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transactions", name: "IX_WalletAndBanks_Id", newName: "IX_WalletAndBank_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_Subcategories_Id", newName: "IX_Subcategory_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_Categories_Id", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Transactions", name: "WalletAndBanks_Id", newName: "WalletAndBank_Id");
            RenameColumn(table: "dbo.Transactions", name: "Subcategories_Id", newName: "Subcategory_Id");
            RenameColumn(table: "dbo.Transactions", name: "Categories_Id", newName: "Category_Id");
        }
    }
}
