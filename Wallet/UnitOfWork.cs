using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentitySample.Models;
using Wallet.Repositories;

namespace Wallet
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly WalletDbContext _context;
        
        public IReportRepository Report { get; private set; }
        public ITransactionRepository Transaction { get; private set; }
        public IManageCatsAndSubsRepository ManageCatsAndSubsRepository { get; }

        public UnitOfWork(WalletDbContext context)
        {
            _context = context;
            Report = new ReportRepository(context);
            Transaction = new TransactionRepository(context);
            ManageCatsAndSubsRepository = new ManageCatsAndSubsRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}