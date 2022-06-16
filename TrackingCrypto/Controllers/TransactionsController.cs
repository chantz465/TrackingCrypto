using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TrackingCrypto.Controllers
{
    public class TransactionsController : Controller
    {
        public IEnumerable<Wallet> Wallet { get; set; }

        private readonly IWalletRepo walletRepo;

        public TransactionsController(IWalletRepo walletRepo)
        {
            this.walletRepo = walletRepo;
        }

        public IActionResult Index(int id)
        {
            var wallet = walletRepo.GetWallet(id);
            var t = new Transactions();
            t.Wallet = (IEnumerable<Wallet>)wallet;
            return View(t);
        }

        //public IActionResult Index()
        //{
        //    var wallets = walletRepo.GetAllWallets();

        //    return View(wallets);
        //}

    }
}
