using System.Collections.Generic;
using System.Data;
using System;
using Dapper;
using TrackingCrypto.Models;
using TrackingCrypto;

namespace TrackingCrypto
{
    public class TransactionsRepo : ITransactionsRepo
    {
        private IDbConnection _conn;

        public TransactionsRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnmerable<Wallet> GetAllWallets()
        {
            return (IEnmerable<Wallet>)_conn.Query<Wallet>("SELECT * FROM Tracking_Crypto.wallet;");
        }

        public Wallet GetWalletAddress(string WalletAddress)
        {
            return _conn.QuerySingle<Wallet>("SELECT * FROM Tracking_Crypto.Wallet WHERE WalletAddress = @WalletAddress",
                new { walletAddress = WalletAddress });
        }


    }
}
