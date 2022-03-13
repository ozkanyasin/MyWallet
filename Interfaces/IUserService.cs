namespace MyWallet
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task DeleteUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsersByStatus();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByStatus(bool IsActive);
        Task<User> UpdateUser(User user);
    }
}