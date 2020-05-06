namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToSubcategory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Subcategories", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Subcategories", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Subcategories", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Subcategories", name: "UserId", newName: "User_Id");
        }
    }
}
