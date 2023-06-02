
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using TrackingCrypto.Models;
using TrackingCrypto;

namespace TrackingCrypto
{
    public interface IWalletRepo
    {
        public IEnumerable<Wallet> GetAllWallets();

        public Wallet GetBalance(double balnace);
        public Wallet GetWallet(int id);

        public Wallet GetCompany(string CompanyName);

        public Wallet GetCoinName(string CoinName);

        public Wallet GetWalletAddress(string WalletAddress);

        
        public void UpdateWallet(Wallet wallet);

        public void InsertWallet(Wallet walletToInsert);

        //public IEnumerable<Transactions> GetTransactions();

        //public IEnumerable<Company> GetCompanies();
        public Wallet AssignCompanies();




        public void DeleteWallet(Wallet wallet); 


    }
}
