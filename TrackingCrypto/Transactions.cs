using System.Collections.Generic;
using TrackingCrypto.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace TrackingCrypto
{
    public class Transactions
    {

        public string Incoming { get; set; }
        public string Outgoing { get; set; }

        public string Balance { get; set; }

        public IEnumerable<Wallet> Wallet { get; set; }



    }
}
