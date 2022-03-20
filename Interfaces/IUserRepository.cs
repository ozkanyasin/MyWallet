namespace MyWallet
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task DeleteUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsersByStatus(bool _IsActive);
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByStatus(bool IsActive);
        Task<User> UpdateUser(User user);
        User FindAccountByEmailAndPassword(LoginDTO loginDTO);
        User findAccountById(int id);
    }
}