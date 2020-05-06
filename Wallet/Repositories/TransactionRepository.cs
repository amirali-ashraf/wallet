using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;
using Wallet.Models.WalletModels;

namespace Wallet.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly WalletDbContext _context;
        public TransactionRepository(WalletDbContext context)
        {
            _context = context;
        }
        public Transaction FindTransaction(int id)
        {
            return _context.Transactions.Find(id);
        }

        public void RemoveTransaction(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public void EditTransaction(Transaction transaction)
        {
            //check this 
            var nTransacion = _context.Transactions.SingleOrDefault(t => t.Id == transaction.Id);
            if (nTransacion != null) ;

        }
       
    }
}