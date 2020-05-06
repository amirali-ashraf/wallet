namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsToTheTransactionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Comment");
        }
    }
}
