using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace Wallet.Models.WalletModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }


        public enum Type
        {
            Income = 1,
            Expenditure = 2
        }
        public Type TypeOfCategory { get; set; }

        //relational contents
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}