using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IdentitySample.Models;
using Wallet.Models.WalletModels;
using Wallet.Repositories;

namespace Wallet.Controllers.APIs
{
    public class TransactionController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionController()
        {
            _unitOfWork = new UnitOfWork(new WalletDbContext());
        }

        [HttpDelete]
        public IHttpActionResult DeleteTransaction(int id)
        {
            var transaction = _unitOfWork.Transaction.FindTransaction(id);
            _unitOfWork.Transaction.RemoveTransaction(transaction);
            _unitOfWork.Complete();
            return Ok();
        }

        
        
    }
}
