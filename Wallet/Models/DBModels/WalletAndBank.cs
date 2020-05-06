using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace Wallet.Models.WalletModels
{
    /// <summary>
    /// this class represents the different bank accounts and also the 
    /// available wallets which are initialize here.
    /// </summary>
    public class WalletAndBank
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal InitialValue { get; set; }
        public decimal BalanceValue { get; set; }

        //relational contents
        public virtual ICollection<Transaction> Transactions { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public byte[] Image { get; set; }
    }
}