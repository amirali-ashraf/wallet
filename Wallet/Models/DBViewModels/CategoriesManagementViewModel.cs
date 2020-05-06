using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wallet.Models.WalletModels;

namespace Wallet.Models.DBViewModels
{
    public class CategoriesManagementViewModel
    {
        public List<Category> ExpenditureCategories { get; set; }
        public List<Category> IncomeCategories { get; set; }
        public List<Subcategory> Subcategories { get; set; }

    }
}