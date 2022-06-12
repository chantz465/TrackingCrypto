using Microsoft.AspNetCore.Mvc;

namespace TrackingCrypto.Controllers
{
    public class TransactionsController : Controller
    {


        private readonly IWalletRepo walletRepo;

        public TransactionsController(IWalletRepo walletRepo)
        {
            this.walletRepo = walletRepo;
        }

        public IActionResult Index()
        {
            var wallets = walletRepo.GetAllWallets();
            var t = new Transactions();
            t.Wallets = wallets;
            return View(t);
        }

        
    }
}
