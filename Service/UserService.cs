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

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            User user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new InvalidOperationException("This user doesn't exist");
            }
            UserDTO userDTO = new UserDTO(){
                Name = user.Name,
                Email = user.Email
            };
            return userDTO;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            User user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new InvalidOperationException("This user doesn't exist");
            }
            UserDTO userDTO = new UserDTO(){
                Name = user.Name,
                Email = user.Email
            };
            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            IEnumerable<User> userList = await _userRepository.GetUsers();
            if(userList == null){
                throw new InvalidOperationException("User list is empty");
            }
            
            IEnumerable<UserDTO> userDTOs = userList.Select(x =>  new UserDTO(){
                Name = x.Name,
                Email = x.Email
            });
            return userDTOs;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByStatus(bool IsActive)
        {
            IEnumerable<User> userList = await _userRepository.GetUsersByStatus(IsActive);
            if(userList == null){
                throw new InvalidOperationException("User list is empty");
            }
            IEnumerable<UserDTO> userDTOs = userList.Select(x =>  new UserDTO(){
                Name = x.Name,
                Email = x.Email
            });
            return userDTOs;
        }

        public async Task<User> UpdateUser(User user)
        {   
            User existingUser = await _userRepository.GetUserByEmail(user.Email);
            if(existingUser != null){
                _userRepository.UpdateUser(user);
                return user;
            }
            throw new MethodAccessException("This user does not exist");
        }
    }
}