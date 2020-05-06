namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToCategory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Categories", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Categories", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Categories", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Categories", name: "UserId", newName: "User_Id");
        }
    }
}
