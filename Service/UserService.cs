namespace MyWallet
{
    public class UserService : IUserService{
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }

        public async Task<User> CreateUser(User incomingUser)
        {
            User user = await _userRepository.GetUserByEmail(incomingUser.Email);
            if(user != null){
                throw new NotImplementedException();
            }
            return await _userRepository.CreateUser(incomingUser);
        }

        public async Task DeleteUser(int id)
        {
            User user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new InvalidOperationException("This user doesn't exist");
            }
            await _userRepository.DeleteUser(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new InvalidOperationException("This user doesn't exist");
            }
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            User user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new InvalidOperationException("This user doesn't exist");
            }
            return user;
        }

        public async Task<User> GetUserByStatus(bool IsActive)
        {
            User user = await _userRepository.GetUserByStatus(IsActive);
            if (user == null)
            {
                throw new InvalidOperationException("This user doesn't exist");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> userList = await _userRepository.GetUsers();
            if(userList == null){
                throw new InvalidOperationException("User list is empty");
            }
            return userList;
        }

        public async Task<IEnumerable<User>> GetUsersByStatus(bool IsActive)
        {
            IEnumerable<User> userList = await _userRepository.GetUsersByStatus(IsActive);
            if(userList == null){
                throw new InvalidOperationException("User list is empty");
            }
            return userList;
        }

        public Task<User> UpdateUser(User user)
        {   
            throw new NotImplementedException(); //TODO
        }
    }
}