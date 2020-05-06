using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wallet.Models.WalletModels;

namespace Wallet.Repositories
{
    public interface ITransactionRepository
    {
        Transaction FindTransaction(int id);
        void RemoveTransaction(Transaction transaction);

        void AddTransaction(Transaction transaction);

        void EditTransaction(Transaction transaction);
    }
}