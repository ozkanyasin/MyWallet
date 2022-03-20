namespace MyWallet
{
    public class WalletRepository : IWalletRepository{
        private readonly BaseDbContext _baseDbContext;
        public WalletRepository(BaseDbContext _baseDbContext)
        {
            this._baseDbContext = _baseDbContext;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            await _baseDbContext.AddAsync(wallet);
            await _baseDbContext.SaveChangesAsync();
            return wallet;
        }

        public async Task DeleteWallet(Wallet wallet)
        {
            _baseDbContext.Remove(wallet);
            await _baseDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Wallet>> GetAllWallets()
        {
            return await _baseDbContext.Wallets.Include(x => x.User).ToListAsync();
        }

        public async Task<Wallet> GetWalletById(int id)
        {
            return await _baseDbContext.Wallets.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Wallet> GetWalletByName(string name)
        {
            return await _baseDbContext.Wallets.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Wallet>> GetWalletsByUserId(int id)
        {
            return await _baseDbContext.Wallets.Where(x => x.User.Id == id).ToListAsync();
        }

        public async Task<Wallet> UpdateWallet(Wallet wallet)
        {
            _baseDbContext.Update(wallet);
            await _baseDbContext.SaveChangesAsync();
            return wallet;
        }
    }
}