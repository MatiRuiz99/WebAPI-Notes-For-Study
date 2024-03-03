using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.Helper;
using Model.Models;
using Model.ViewModel;
using Service.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly NotesWebsiteContext _context;
        private readonly AppSettings _appSettings;

        public AuthService(NotesWebsiteContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public string SignIn(SignInViewModel User)
        {
            if (string.IsNullOrEmpty(User.Email))
            {
                return "Email is required";
            }

            if (string.IsNullOrEmpty(User.Password))
            {
                return "Password is required";
            }

            Users? user = _context.Users.FirstOrDefault(x => x.Email == User.Email);

            if (user != null)
            {
                return "Email is already in use";
            }

            _context.Users.Add(new Users()
            {
                
                Email = User.Email,
                Password = User.Password.GetSHA256(),
               
            });
            _context.SaveChanges();

            string response = GetToken(_context.Users.OrderBy(x => x.Id).Last());

            return response;
        }

        public string Login(LoginViewModel User)
        {
            Users? user = _context.Users.FirstOrDefault(x => x.Email == User.Email && x.Password == User.Password.GetSHA256());

            if (user == null)
            {
                return string.Empty;
            }

            return GetToken(user);
        }

        private string GetToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, _context.Role.First(x => x.Id == user.RoleId).Description)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
