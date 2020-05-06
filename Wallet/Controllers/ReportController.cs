using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Wallet.Models.DBViewModels;
using Wallet.Models.WalletModels;

namespace Wallet.Controllers
{
    public class ReportController : Controller
    {
        private readonly WalletDbContext _context;

        public ReportController()
        {
            _context = new WalletDbContext();
        }
        // GET: Report        

        [Authorize]
        public ActionResult ReportViewer()
        {
            var userId = User.Identity.GetUserId();
            var reportViewModel = new ReportViewModel
            {
                //todo: the transaction date filtering should be modified
                Transactions = _context.Transactions.Where(t => t.UserId == userId && t.TransactionDate == DateTime.Today.Date).ToList(),
                Categories = _context.Categories.Where(c => c.UserId == userId).ToList(),
                Subcategories = _context.Subcategories.Where(s => s.UserId == userId).ToList(),
                FromDate = DateTime.Today.Date,
                ToDate = DateTime.Now.Date,

            };
            return View(reportViewModel);
        }

        [Authorize]
        public ActionResult ReportListByTransactionDate(ReportViewModel data)
        {
            var userId = User.Identity.GetUserId();
            IEnumerable<Transaction> report = GetReportTypeSwitcherByTransactionDate(data.FromDate, data.ToDate, 
                                                                    data.CategoryType, data.CategoryId, 
                                                                    data.SubcategoryId);

            var model = new ReportViewModel()
            {
                //todo: the transaction date filtering should be modified
                Transactions = report.ToList(),
                Categories = _context.Categories.Where(c => c.UserId == userId).ToList(),
                Subcategories = _context.Subcategories.Where(s => s.UserId == userId).ToList(),
                FromDate = data.FromDate,
                ToDate = data.ToDate,
                CategoryType = data.CategoryType,
                CategoryId = data.CategoryId,
                SubcategoryId = data.SubcategoryId
            };

            return View("ReportViewer", model);
        }


        public IEnumerable<Transaction> GetReportTypeSwitcherByTransactionDate(DateTime fromDate, DateTime toDate, Category.Type? categoryType,
            int? categoryId, int? subcategoryId)
        {
            if (categoryType == null)
            {
                return GetReportByTransactionDate(fromDate, toDate);
            }

            if (categoryId == null)
            {
                return GetReportByTransactionDate(fromDate, toDate, categoryType);
            }

            if (subcategoryId == null)
            {
                return GetReportByTransactionDate(fromDate, toDate, categoryType, categoryId);
            }

            if (subcategoryId != null)
            {
                return GetReportByTransactionDate(fromDate, toDate, categoryType, categoryId, subcategoryId);
            }

            return null;
        }

        public IEnumerable<Transaction> GetReportByTransactionDate(DateTime fromDate, DateTime toDate)
        {
            var userId = User.Identity.GetUserId();
            var report = _context.Transactions.Where(t => t.TransactionDate >= fromDate &&
                                                          t.TransactionDate <= toDate &&
                                                          t.UserId == userId);
            return report;
        }

        public IEnumerable<Transaction> GetReportByTransactionDate(DateTime fromDate, DateTime toDate, Category.Type? categoryType)
        {
            var userId = User.Identity.GetUserId();
            var report = _context.Transactions.Where(t => t.TransactionDate >= fromDate &&
                                                          t.TransactionDate <= toDate &&
                                                          t.Category.TypeOfCategory == categoryType &&
                                                          t.UserId == userId);
            return report;
        }

        public IEnumerable<Transaction> GetReportByTransactionDate(DateTime fromDate, DateTime toDate, Category.Type? categoryType, int? categoryId)
        {
            var userId = User.Identity.GetUserId();
            var report = _context.Transactions.Where(t => t.TransactionDate >= fromDate &&
                                                          t.TransactionDate <= toDate &&
                                                          t.Category.TypeOfCategory == categoryType &&
                                                          t.CategoryId == categoryId &&
                                                          t.UserId == userId);
            return report;
        }

        public IEnumerable<Transaction> GetReportByTransactionDate(DateTime fromDate, DateTime toDate, Category.Type? categoryType, int? categoryId, int? subcategoryId)
        {
            var userId = User.Identity.GetUserId();
            var report = _context.Transactions.Where(t => t.TransactionDate >= fromDate &&
                                                          t.TransactionDate <= toDate &&
                                                          t.Category.TypeOfCategory == categoryType &&
                                                          t.CategoryId == categoryId &&
                                                          t.SubcategoryId == subcategoryId &&
                                                          t.UserId == userId);
            return report;
        }
    }
}