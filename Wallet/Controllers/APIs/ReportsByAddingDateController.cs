using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IdentitySample.Models;
using Wallet.Models.WalletModels;

namespace Wallet.Controllers.APIs
{
    public class ReportsByAddingDateController : ApiController
    {
        WalletDbContext db = new WalletDbContext();

        [HttpGet]
        public ApplicationUser GetReport()
        {
            var report = db.Users.First();

            return report;
        }
    }
}
