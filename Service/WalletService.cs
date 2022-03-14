namespace MyWallet
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        public WalletService(IWalletRepository _walletRepository)
        {
            this._walletRepository = _walletRepository;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            Wallet existing = await _walletRepository.GetWalletById(wallet.Id);
            if (existing != null)
            {
                throw new InvalidOperationException("This wallet has already exist");
            }
            return await _walletRepository.CreateWallet(wallet);
        }

        public async Task DeleteWallet(int id)
        {
            Wallet wallet = await _walletRepository.GetWalletById(id);
            if (wallet == null)
            {
                throw new InvalidOperationException("This wallet doesn't exist");
            }
            await _walletRepository.DeleteWallet(wallet);
        }

        public async Task<IEnumerable<Wallet>> GetAllWallets()
        {
            IEnumerable<Wallet> wallets = await _walletRepository.GetAllWallets();
            if (wallets == null)
            {
                throw new InvalidOperationException("Wallet list empty");
            }
            return wallets;
        }

        public async Task<Wallet> GetWalletById(int id)
        {
            Wallet wallet = await _walletRepository.GetWalletById(id);
            if (wallet == null)
            {
                throw new InvalidOperationException("This wallet doesn't exist");
            }
            return wallet;
        }

        public async Task<Wallet> GetWalletByName(string name)
        {
            Wallet wallet = await _walletRepository.GetWalletByName(name);
            if (wallet == null)
            {
                throw new InvalidOperationException("This wallet doesn't exist");
            }
            return wallet;
        }

        public async Task<IEnumerable<Wallet>> GetWalletsByUserId(int id)
        {
            IEnumerable<Wallet> wallets = await _walletRepository.GetWalletsByUserId(id);
            if (wallets == null)
            {
                throw new InvalidOperationException("Wallet list empty");
            }
            return wallets;
        }

        public Task<Wallet> UpdateWallet(Wallet wallet)
        {
            throw new NotImplementedException(); //Todo Update
        }
    }
}