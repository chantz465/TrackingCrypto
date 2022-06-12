using System.Collections.Generic;
using System.Data;
using System;
using Dapper;
using TrackingCrypto.Models;
using TrackingCrypto;

namespace TrackingCrypto
{
    public class WalletRepo : IWalletRepo
    {
        private IDbConnection _conn;

        public WalletRepo(IDbConnection conn)
        {
            _conn = conn;
        }


        public IEnumerable<Wallet> GetAllWallets()
        {
            return _conn.Query<Wallet>("SELECT * FROM Tracking_Crypto.wallet;");

        }

        public IEnumerable<Company> GetCompanies()
        {
            return _conn.Query<Company>("SELECT * FROM Tracking_Crypto.company_name;");
        }

        

        public Wallet GetWallet(int id)
        {

            return _conn.QuerySingle<Wallet>("SELECT * FROM Tracking_Crypto.wallet WHERE WalletID = @Id",
                new { Id = id });



        }

        public Wallet GetCompany(string CompanyName)
        {
            return _conn.QuerySingle<Wallet>("SELECT * FROM Tracking_Crypto.Wallet WHERE CompanyName = @companyName",
                new { companyName = CompanyName });
        }

        public Wallet GetCoinName(string CoinName)
        {
            return _conn.QuerySingle<Wallet>("SELECT * FROM Tracking_Crypto.Wallet WHERE CoinName = @CoinName",
                new { coinName = CoinName });
        }

        public Wallet GetWalletAddress(string WalletAddress)
        {
            return _conn.QuerySingle<Wallet>("SELECT * FROM Tracking_Crypto.Wallet WHERE WalletAddress = @WalletAddress",
                new { walletAddress = WalletAddress });
        }

        public void UpdateWallet(Wallet wallet)
        {
            _conn.Execute("UPDATE Tracking_Crypto.Wallet SET CompanyName = @CompanyName, CoinName = @CoinName WHERE WalletID = @id",
             new { companyName = wallet.CompanyName, coinName = wallet.CoinName, id = wallet.WalletID });
        }


        public void InsertWallet(Wallet walletToInsert)
        {
            _conn.Execute("INSERT INTO Tracking_Crypto.Wallet (WalletID, CompanyName, CoinName, WalletAddress) VALUES (@walletID, @companyName, @coinName, @walletaddress);",
                new { walletID = walletToInsert.WalletID, companyName = walletToInsert.CompanyName, coinName = walletToInsert.CoinName, walletAddress = walletToInsert.WalletAddress });
        }

        public IEnumerable<Transactions> GetTransactions()
        {
            return _conn.Query<Transactions>("SELECT * FROM Tracking_Crypto.Transactions;");
        }

        //public Wallet AssignCompanies()
        //{
        //    throw new NotImplementedException();
        //}



        public Wallet AssignCompanies()
        {
            var companyList = GetCompanies();
            var wallet = new Wallet();
            //wallet.Companyies = companyList;
            return wallet;
        }

        public void DeleteWallet(Wallet wallet)
        {
            //_conn.Execute("DELETE FROM company_name WHERE WalletID = @id;", new { id = wallet.WalletID });
            _conn.Execute("DELETE FROM Tracking_Crypto.Wallet WHERE WalletID = @id;", new { id = wallet.WalletID });
            //_conn.Execute("DELETE FROM transactions WHERE WalletId = @id;", new { id = wallet.WalletID });
        }
    }
}
