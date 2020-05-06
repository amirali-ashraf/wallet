using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IdentitySample.Models;

namespace Wallet.Models.WalletModels
{
    public class Transaction
    {
        public int Id { get; set; }

        //Shows the transaction date
        //[RegularExpression(@"^((((31\/(0?[13578]|1[02]))|((29|30)\/(0?[1,3-9]|1[0-2])))\/(1[6-9]|[2-9]\d)?\d{2})|(29\/0?2\/(((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))|(0?[1-9]|1\d|2[0-8])\/((0?[1-9])|(1[0-2]))\/((1[6-9]|[2-9]\d)?\d{2})) (20|21|22|23|[0-1]?\d):[0-5]?\d$", ErrorMessage = "Date must be in the format of : dd/mm/yyyy hh:mm")]
        [Required(ErrorMessage = "Insert the Date")]
        [DataType(DataType.DateTime)]
        public DateTime TransactionDate { get; set; }

        //It represents the time which the transaction is added to the table
        public DateTime AddedDate { get; set; }

        //It represents the value of the transation
        [Required(ErrorMessage = "Insert the Date")]
        public decimal TransationValue { get; set; }

        //relational cases        
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Insert the Category")]
        public int CategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public int SubcategoryId { get; set; }
        public virtual WalletAndBank WalletAndBank { get; set; }
        public int WalletAndBankId { get; set; }
        public string Comment { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }


    }
}