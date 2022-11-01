﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Models.Auth;
using Ofertownik.Data.Model;
using Ofertownik.Helpers;
using Ofertownik.Repositories.IRpositories;
using System;
using System.Threading.Tasks;

namespace Ofertownik.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly ApplicationSettings _settings;

        public AuthRepository(UserManager<User> userManager,
                              IOptions<ApplicationSettings> settings,
                              ILoggerManager logger)
        {
            _userManager = userManager;
            _logger = logger;
            _settings = settings.Value;
        }

        public void ChangePassword(int id, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(LoginDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(RegisterDTO registerDTO)
        {
            try
            {
                var user = new User
                {
                    UserName = registerDTO.UserName
                };
                var result = await _userManager.CreateAsync(user, registerDTO.Password);
              
                return user;
              
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return null;
                
            }
         

          
        }

        public string ResetPassword(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<bool, string>> UserValidation(string userName, string nip, string municipalitie)
        {
            throw new NotImplementedException();
        }
    }
}