namespace Wallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SPCalculatesWalletAndBanksBalance : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE PROCEDURE [dbo].[sp_WalletAndBanksBalance]
            @WalletBankId int
            As
            SELECT SUM(TransationValue)
            FROM Transactions
            WHERE Transactions.WalletAndBankId = @WalletBankId ");
        }
        
        public override void Down()
        {
        }
    }
}
