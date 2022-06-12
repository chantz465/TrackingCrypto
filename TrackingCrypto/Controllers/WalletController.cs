using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using TrackingCrypto;
using TrackingCrypto.Models;


namespace TrackingCrypto
{
    public class WalletController : Controller
    {
        private readonly IWalletRepo repo;

        public WalletController(IWalletRepo repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var wallets = repo.GetAllWallets();
            
            return View(wallets);
        }

        public IActionResult ViewWallet(int id)
        {
            var wallet = repo.GetWallet(id);

            return View(wallet);
            
        }



        public IActionResult UpdateWallet(int id)
        {
            Wallet prod = repo.GetWallet(id);

            if (prod == null)
            {
                return View("ProductNotFound");

            }
            return View(prod);
        }



        public IActionResult UpdateWalletToDatabase(Wallet wallet)
        {
            repo.UpdateWallet(wallet);

            return RedirectToAction("ViewWallet", new { id = wallet.WalletID });
        }

        public IActionResult InsertWallet()
        {
            var prod = repo.AssignCompanies();
            return View(prod);
        }

        public IActionResult InsertWalletToDatabase(Wallet walletToInsert)
        {
            repo.InsertWallet(walletToInsert);

            return RedirectToAction("index");
        }

        public IActionResult DeleteWallet(Wallet wallet)
        {
            repo.DeleteWallet(wallet);

            return RedirectToAction("index");

        }

    }
}
