namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTheApplicationUserToTheCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "User_Id");
            AddForeignKey("dbo.Categories", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "User_Id" });
            DropColumn("dbo.Categories", "User_Id");
        }
    }
}
