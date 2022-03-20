namespace MyWallet
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task DeleteUser(int id);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<IEnumerable<UserDTO>> GetUsersByStatus(bool IsActive);
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> GetUserByEmail(string email);
        Task<User> UpdateUser(User user);
    }
}