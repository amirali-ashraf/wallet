using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wallet.Models.WalletModels;

namespace Wallet.Models.DBViewModels
{
    public class ReportViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public Transaction Transaction { get; set; }
       
        public IEnumerable<Category> Categories { get; set; }                
        
        public IEnumerable<Subcategory> Subcategories { get; set; }


        //Data Input Fields

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }


        public Category.Type? CategoryType { get; set; }
        public int? CategoryId { get; set; }

        public int? SubcategoryId { get; set; }
        public int? WalletAndBankId { get; set; }




    }
}