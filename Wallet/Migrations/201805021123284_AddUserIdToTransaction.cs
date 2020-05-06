namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToTransaction : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Transactions", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transactions", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Transactions", name: "UserId", newName: "User_Id");
        }
    }
}
