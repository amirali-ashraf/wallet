using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Wallet.Models;
using Wallet.Models.DBViewModels;
using Wallet.Models.WalletModels;

namespace WalletIdentity.Controllers
{
    public class DailyRecordsController : Controller
    {
        WalletDbContext db = new WalletDbContext();


        // GET: DailyEvents   

        public ActionResult DailyRecords()
        {
            //this function adds new record to the table
            AddRecordViewModel CASvm = new AddRecordViewModel();
            string userId = User.Identity.GetUserId();
            CASvm.Category = db.Categories.Where(c => c.UserId == userId).ToList();
            CASvm.Subcategory = db.Subcategories.Where(s => s.UserId == userId).ToList();
            CASvm.Transaction = new Transaction();
            CASvm.WalletAndBanks = db.WalletAndBanks.ToList();
            CASvm.Transactions = db.Transactions.Where(x => x.AddedDate == DateTime.Today.Date && x.UserId == userId).ToList();
            CASvm.TransactionDate = DateTime.Now;

            return View(CASvm);
        }
        public JsonResult TypeChange(Category.Type type)
        {
            string userId = User.Identity.GetUserId();

            //this is used to change type between two items (Expenditure and Income)
            // and using this will lead to change the category dropbox
            var query = db.Categories.Where(c => c.TypeOfCategory == type && c.UserId == userId).ToList();
            if (query == null)
                return Json(false);
            else
                return Json(query.Select(x => new { name = x.Name.ToString(), Id = x.Id.ToString() }).ToList());
        }

        public JsonResult CategoryChange(int? catId)
        {
            string userId = User.Identity.GetUserId();

            //this method starts to work when we choose the type to show the
            //sub-categories
            var query = db.Subcategories.Where(s => s.Category.Id == catId && s.UserId == userId).ToList();
            if (query == null)
                return Json(false);
            else
                return Json(query.Select(x => new { name = x.Name.ToString(), Id = x.Id.ToString() }).ToList());
        }



        //it is better to remove this code but beforehand save this code as a sample code
        public JsonResult ListRecords()
        {
            string userId = User.Identity.GetUserId();

            // I think it is better to add the new daily data in the list rather than the transaction date
            var queryByToday = db.Transactions.Where(t => t.TransactionDate == DateTime.Today && t.UserId == userId).ToList();

            return Json(
                queryByToday.Select(x =>
                new
                {
                    transactionId = x.Id,
                    typeOfTransaction = x.Category.TypeOfCategory.ToString(),
                    categoryName = x.Category.Name,
                    subcategoryName = x.Subcategory.Name,
                    value = x.TransationValue
                })
            );

        }

        //this method is used to add the new records to the table of daily records. this method uses json.
        public JsonResult AddNewRecord(
            DateTime transactionDate,
            int selectedSubcategory,
            int selectedCategory,
            decimal transactionValue,
            string transactionComment,
            int walletAndBanks

            )
        {
            string userId = User.Identity.GetUserId();
            var typeOfCategory = (int) db.Categories.Where(c => c.Id == selectedCategory).Select(c=>c.TypeOfCategory).First();
            Transaction tr = new Transaction();
            if (db.Subcategories.Select(x => x.Id).Contains(selectedSubcategory))
            {
                tr.TransactionDate = transactionDate;
                tr.AddedDate = DateTime.Now;
                tr.CategoryId = selectedCategory;
                tr.SubcategoryId = selectedSubcategory;
                //check the category type and then add it as a positive or negative number 
                if (typeOfCategory == 1)
                {
                    tr.TransationValue = transactionValue;
                }
                else if (typeOfCategory == 2)
                {
                    tr.TransationValue = -transactionValue;
                }

                tr.Comment = transactionComment;
                tr.WalletAndBankId = walletAndBanks;
                tr.UserId = userId;
                db.Transactions.Add(tr);
                db.SaveChanges();
                return Json(true);
            }
            else
            {
                return Json(false);
            }


        }

        // this method is used to remove the record from the table in the daily records
        public ActionResult RemoveRecord(int id)
        {
            var queryToRemove = db.Transactions.Find(id);
            if (queryToRemove != null)
            {
                db.Transactions.Remove(queryToRemove);
            }
            db.SaveChanges();
            return Json(true);
        }


        //NewTransaction Field
        public ActionResult AddTransaction(AddRecordViewModel data)
        {
            var userId = User.Identity.GetUserId();
            Transaction transaction = new Transaction()
            {
                TransactionDate = data.TransactionDate,
                AddedDate = DateTime.Now.Date,
                TransationValue = data.TransactionValue,
                CategoryId = data.CategoyId,
                SubcategoryId = data.SubcategoryId,
                WalletAndBankId = data.WalletAndBankId,
                Comment = data.Comment,
                UserId = userId

            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
            return RedirectToAction("DailyRecords");
        }

    }
}