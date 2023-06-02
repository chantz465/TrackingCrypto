using System.Collections.Generic;
using TrackingCrypto.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace TrackingCrypto
{
    public class Wallet
    {
        public int WalletID { get; set; }

        public int CompanyName { get; set; }
        public string CoinName { get; set; }
        public string WalletAddress { get; set; }

        public double Balance { get; set; }


    

        public IEnumerable<Company> Companies { get; set; }

        public IEnumerable<Wallet> Wallets { get; set; }
    }
}
