using Models.Auth;
using Ofertownik.Data.Model;
using System;
using System.Threading.Tasks;

namespace Ofertownik.Repositories.IRpositories
{
    public interface IAuthRepository
    {
        Task<User> Login(LoginDTO userDTO);
        Task<User> Register(RegisterDTO registerDTO);
        Task<Tuple<bool, string>> UserValidation(string userName, string nip, string municipalitie);
        string ResetPassword(string userName);
        void ChangePassword(int id, string password);
    }
}
