using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService _userService)
    {
        this._userService = _userService;
    }

    [HttpPost]
    public async Task<User> CreateUser(User user){
        return await _userService.CreateUser(user);
    }

    [HttpGet]
    public async Task<IEnumerable<UserDTO>> GetAllUsers(){
        return await _userService.GetUsers();
    }

    [HttpGet("id")]
    public async Task<User> GetUserById(int id){
        return await _userService.GetUserById(id);
    }

    [HttpGet("email")]
    public async Task<User> GetUserByEmail(string email){
        return await _userService.GetUserByEmail(email);
    }

    [HttpGet("IsActive")]
    public async Task<IEnumerable<UserDTO>> GetUsersByStatus(bool IsActive){
        return await _userService.GetUsersByStatus(IsActive);
    }

    [HttpDelete("id")]
    public async Task DeleteUser(int id){
        await _userService.DeleteUser(id);
    }

    //Todo Update Eklenecek

}
