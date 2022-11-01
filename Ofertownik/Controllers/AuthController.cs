using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Auth;
using Ofertownik.Data.Model;
using Ofertownik.Repositories.IRpositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ofertownik.Controllers
{
    public class AuthController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthRepository _authRepository;
        private readonly ApplicationSettings _settings;

        public AuthController(UserManager<User> userManager,
                              IOptions<ApplicationSettings> settings,
                              IAuthRepository authRepository)
        {
            _userManager = userManager;
            _authRepository = authRepository;
            _settings = settings.Value;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register (RegisterDTO registerDTO)
        {
          
            var result =  await _authRepository.Register(registerDTO);

            if (result != null)
            {
                return Ok();
            }

            return BadRequest();

        }

        //public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
        //{

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_settings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var encryptedToken =  tokenHandler.WriteToken(token);

        //    return encryptedToken;

        //}
    }
}
