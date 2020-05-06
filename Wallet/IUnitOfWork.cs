using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wallet.Repositories;

namespace Wallet
{
    public interface IUnitOfWork
    {
        IReportRepository Report { get; }
        ITransactionRepository  Transaction { get; }
        IManageCatsAndSubsRepository ManageCatsAndSubsRepository { get; }
        void Complete();
    }
}