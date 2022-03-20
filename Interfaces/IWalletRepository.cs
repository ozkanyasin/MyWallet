namespace MyWallet{
    public interface IWalletRepository{
        Task<Wallet> CreateWallet(Wallet wallet);
        Task DeleteWallet(Wallet wallet);
        Task<Wallet> GetWalletById(int id);
        Task<Wallet> GetWalletByName(string name);
        Task<IEnumerable<Wallet>> GetWalletsByUserId(int id);
        Task<IEnumerable<Wallet>> GetAllWallets();
        Task<Wallet> UpdateWallet(Wallet wallet);
    }
}