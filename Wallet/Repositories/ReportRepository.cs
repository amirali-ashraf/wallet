using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;
using Wallet.Models.WalletModels;

namespace Wallet.Repositories
{
    public class ReportRepository:IReportRepository
    {
        private readonly WalletDbContext _context;
        public ReportRepository(WalletDbContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Transaction> GetReport()
        {
            return _context.Transactions.ToList();
        }
        
        public IEnumerable<Transaction> GetReport(DateTime fromDate, DateTime toDate)
        {
            return _context.Transactions.Where(x =>
                x.TransactionDate >= fromDate &&
                x.TransactionDate <= toDate).ToList();
        }

        
        public IEnumerable<Transaction> GetReport(DateTime fromDate, DateTime toDate,int type)
        {
            return _context.Transactions.Where(x =>
                x.TransactionDate >= fromDate &&
                x.TransactionDate <= toDate &&
                (int)x.Category.TypeOfCategory == type).ToList();
        }

        
        public IEnumerable<Transaction> GetReport(DateTime fromDate, DateTime toDate, int type, int categoryId)
        {
            return _context.Transactions.Where(x =>
                x.TransactionDate >= fromDate &&
                x.TransactionDate <= toDate &&
                (int)x.Category.TypeOfCategory == type &&
                x.CategoryId == categoryId).ToList();
        }

        
        public IEnumerable<Transaction> GetReport(DateTime fromDate, DateTime toDate, int type, int categoryId,int subcategoryId)
        {
            return _context.Transactions.Where(x =>
                x.TransactionDate >= fromDate &&
                x.TransactionDate <= toDate &&
                (int)x.Category.TypeOfCategory == type &&
                x.CategoryId == categoryId &&
                x.SubcategoryId == subcategoryId).ToList();
        }



    }
}