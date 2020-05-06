using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Wallet.Models.DBViewModels;
using Wallet.Models.DTOs;
using Wallet.Models.WalletModels;

namespace Wallet.Controllers
{
    [Authorize]
    public class WalletAndBanksController : Controller
    {
        private readonly WalletDbContext _context;

        public WalletAndBanksController()
        {
            _context = new WalletDbContext();
        }
        // GET: WalletAndBanks
        public ActionResult WalletAndBanks()
        {
            var userId = User.Identity.GetUserId();
            WalletAndBanksViewModel walletAndBanks = new WalletAndBanksViewModel();
            walletAndBanks.WalletAndBanks = _context.WalletAndBanks.Where(w => w.UserId == userId).ToList();
            return View(walletAndBanks);
        }

        public ActionResult AddNewWalletAndBank(WalletAndBank newWalletAndBank )
        {
            var userId = User.Identity.GetUserId();
            WalletAndBank walletAndBank = new WalletAndBank
            {
                Name = newWalletAndBank.Name,
                InitialValue = newWalletAndBank.InitialValue,
                BalanceValue = newWalletAndBank.InitialValue,
                //todo add the image to the new wb
                UserId = userId
            };
            _context.WalletAndBanks.Add(walletAndBank);
            _context.SaveChanges();
            return RedirectToAction("WalletAndBanks", "WalletAndBanks");
        }

        public ActionResult EditWalletAndBank(WalletAndBank model)
        {
            var userId = User.Identity.GetUserId();
            var selectedItem = _context.WalletAndBanks.Find(model.Id);
            if (selectedItem != null && selectedItem.UserId == userId)
            {
                selectedItem.Name = model.Name;
                _context.SaveChanges();
            }
            
            return RedirectToAction("WalletAndBanks", "WalletAndBanks");
        }

        public ActionResult DeleteWalletAndBank(int id)
        {
            var userId = User.Identity.GetUserId();
            var selectedItem = _context.WalletAndBanks.Find(id);
            if (selectedItem != null && selectedItem.UserId == userId)
            {
                _context.WalletAndBanks.Remove(selectedItem);
                _context.SaveChanges();
            }

            return RedirectToAction("WalletAndBanks", "WalletAndBanks");
        }
    }
}