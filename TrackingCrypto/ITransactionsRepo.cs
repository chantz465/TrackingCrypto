namespace TrackingCrypto
{
    public interface ITransactionsRepo
    {
        public IEnmerable<Wallet> GetAllWallets();

        public Wallet GetWalletAddress(string walletAddress);


    }
}
