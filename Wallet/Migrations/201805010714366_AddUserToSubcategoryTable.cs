namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToSubcategoryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subcategories", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Subcategories", "User_Id");
            AddForeignKey("dbo.Subcategories", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Subcategories", new[] { "User_Id" });
            DropColumn("dbo.Subcategories", "User_Id");
        }
    }
}
