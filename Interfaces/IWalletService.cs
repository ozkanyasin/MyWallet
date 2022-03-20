namespace MyWallet{
    public interface IWalletService{
        Task<Wallet> CreateWallet(Wallet wallet);
        Task DeleteWallet(int id);
        Task<Wallet> GetWalletById(int id);
        Task<Wallet> GetWalletByName(string name);
        Task<IEnumerable<Wallet>> GetWalletsByUserId(int id);
        Task<IEnumerable<Wallet>> GetAllWallets();
        Task<Wallet> UpdateWallet(Wallet wallet);
    }
}