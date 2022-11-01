using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ofertownik.Data.Model
{
    public class User : IdentityUser
    {
        [Key]
        public int UserId { get; set; }
    }
}
