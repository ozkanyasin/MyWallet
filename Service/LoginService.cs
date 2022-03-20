using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyWallet;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class LoginService : ILoginService
{
    private readonly AppSettings _appSettings;
    private readonly IUserRepository _userRepository;

    public LoginService(IOptions<AppSettings> appSettings,IUserRepository userRepository )
    {
        _appSettings = appSettings.Value;
        this._userRepository = userRepository;
    }

    public LoginResponseDTO Authenticate(LoginDTO model)
    {
        var User = _userRepository.FindAccountByEmailAndPassword(model);
        if (User == null) return null;
        var token = generateJwtToken(User);

        return new LoginResponseDTO(token);
    }

    public User findAccountById(int id)
    {
        return _userRepository.findAccountById(id);
    }

    private string generateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}