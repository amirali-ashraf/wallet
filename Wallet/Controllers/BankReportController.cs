using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Wallet.Models.DBViewModels;
using Wallet.Models.WalletModels;

namespace Wallet.Controllers
{
    public class BankReportController : Controller
    {
        private readonly WalletDbContext _context;

        public BankReportController()
        {
            _context = new WalletDbContext();
        }
        // GET: BankReport
        public ActionResult BankReport()
        {
            var userId = User.Identity.GetUserId();
            var reportViewModel = new BankReportViewModel
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,
                WalletAndBanks = _context.WalletAndBanks.Where(w => w.UserId == userId).ToList()
            };
            return View(reportViewModel);
        }


        [HttpGet]
        public ActionResult BankReportByName(BankReportViewModel data)
        {
            var userId = User.Identity.GetUserId();           
            var bankId = new SqlParameter("@WalletBankId", data.BankId);

            var reportViewModel = new BankReportViewModel
            {
                Transactions = _context.Transactions.Where(t => t.WalletAndBankId == data.BankId
                                                                && t.UserId == userId
                                                                && t.TransactionDate >= data.FromDate
                                                                && t.TransactionDate <= data.ToDate)
                    .ToList(),
                WalletAndBanks = _context.WalletAndBanks.Where(w => w.UserId == userId).ToList(),
                BankInitialValue = _context.WalletAndBanks.Where(w=>w.Id==data.BankId).Select(w => w.InitialValue).FirstOrDefault(),
                FromDate = data.FromDate,
                ToDate = data.ToDate,
                BankId = data.BankId,
                
            };

            // check the availability of transaction to avoid return null
            // todo: check the wallet and bank balance calculator stored procedure and fix the bug
            if (reportViewModel.Transactions.Count>0)
                reportViewModel.BalanceValue = reportViewModel.BankInitialValue + _context.Database
                    .SqlQuery<decimal>("[dbo].[sp_WalletAndBanksBalance] @WalletBankId", bankId).Single();
            

            return View("BankReport", reportViewModel);
        }
    }
}