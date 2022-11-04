using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        private readonly ApplicationSettings _settings;

        public AuthController(UserManager<User> userManager,
                              IOptions<ApplicationSettings> settings,
                              IAuthRepository authRepository,
                              IConfiguration config)
        {
            _userManager = userManager;
            _authRepository = authRepository;
            _config = config;
            _settings = settings.Value;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register (RegisterDTO registerDTO)
        {
            if (!IsValidEmail(registerDTO.UserName))
            {
                return BadRequest("Rejestracja możliwa tylko za pomocą adresu email");
            }

            var result =  await _authRepository.Register(registerDTO);

            if (result != null)
            {
                return Ok();
            }

            return BadRequest();

        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
        {
            if (!IsValidEmail(loginDTO.UserName))
            {
                return BadRequest("Logowanie możliwe tylko za pomocą adresu email");
            }

            var userFromRepository = await _authRepository.Login(loginDTO.UserName.ToLower(), loginDTO.Password);
            if(userFromRepository == null)
            {
                Unauthorized();
            }

            var claims = new[]
           {
                new Claim(ClaimTypes.NameIdentifier, userFromRepository.Id),
                new Claim(ClaimTypes.Name, userFromRepository.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("ApplicationSettings:Token").Value));

            var creeds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creeds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
