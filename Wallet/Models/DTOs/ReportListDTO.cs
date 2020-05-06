using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wallet.Models.WalletModels;

namespace Wallet.Models.DTOs
{
    public class ReportListDto
    {


        // this Dto converts the Transaction class to the readable class in the API



        public int Id { get; set; }

        public DateTime TransactionDate { get; set; }

        public DateTime AddedDate { get; set; }

        public decimal TransationValue { get; set; }

        public string CategoryName { get; set; }

        public string SubcategoryName { get; set; }

        public string WalletAndBankName { get; set; }

        public string Comment { get; set; }

        public string CategoryTypeOfCategory { get; set; }

    }
}