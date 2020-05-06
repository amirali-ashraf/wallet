using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace Wallet.Models.WalletModels
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        //relational contents
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}