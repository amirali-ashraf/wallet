namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdAndImageToWalletAndBanks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WalletAndBanks", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.WalletAndBanks", "Image", c => c.Binary());
            CreateIndex("dbo.WalletAndBanks", "UserId");
            AddForeignKey("dbo.WalletAndBanks", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalletAndBanks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WalletAndBanks", new[] { "UserId" });
            DropColumn("dbo.WalletAndBanks", "Image");
            DropColumn("dbo.WalletAndBanks", "UserId");
        }
    }
}
