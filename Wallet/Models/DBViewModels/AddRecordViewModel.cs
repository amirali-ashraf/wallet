using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wallet.Models.WalletModels;

namespace Wallet.Models.DBViewModels
{
    public class AddRecordViewModel
    {
        public List<Category> Category { get; set; }
        public List<Subcategory> Subcategory { get; set; }
        public Transaction Transaction { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<WalletAndBank> WalletAndBanks { get; set; }


        //Data Input Fields
        

        [Required]
        [Display(Name = "Insert the Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Display(Name = "Select the Category")]
        public int CategoyId { get; set; }

        [Required]
        [Display(Name = "Select the Subcategory")]
        public int SubcategoryId { get; set; }

        [Required()]
        [Display(Name = "Transaction Value")]
        [Range(0.01, 9999999999999999.99,ErrorMessage ="The value is not in range.")]
        public decimal TransactionValue { get; set; }

        [Required]
        [Display(Name = "Choose a Wallet or Bank")]
        public int WalletAndBankId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name ="Comment")]
        public string Comment { get; set; }
    }
}