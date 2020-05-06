using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wallet.Models.WalletModels;

namespace Wallet.Models.DBViewModels
{
    public class BankReportViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public List<WalletAndBank> WalletAndBanks { get; set; }
        public decimal BankInitialValue { get; set; }

        public decimal BalanceValue { get; set; }


        //Data Input Annotation
        [Required]
        [Display(Name ="Select the Bank")]
        public int BankId { get; set; }

        [Required]
        [Display(Name = "From Date")]        
        public DateTime FromDate { get; set; }

        [Required]
        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }


    }
}