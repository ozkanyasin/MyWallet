namespace MyWallet
{
    public class UserRepository : IUserRepository{
        private readonly BaseDbContext _baseDbContext;
        public UserRepository(BaseDbContext _baseDbContext)
        {
            this._baseDbContext = _baseDbContext;
        }

        public async Task<User> CreateUser(User user)
        {
            await _baseDbContext.AddAsync(user);
            await _baseDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(User user)
        {
            _baseDbContext.Remove(user);
            await _baseDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _baseDbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _baseDbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByStatus(bool _IsActive)
        {
            return await _baseDbContext.Users.Where(x => x.IsActive == _IsActive).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _baseDbContext.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByStatus(bool _IsActive)
        {
            return await _baseDbContext.Users.Where(x => x.IsActive ==_IsActive).ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            _baseDbContext.Update(user);
            await _baseDbContext.SaveChangesAsync();
            return user;
        }
    }
}