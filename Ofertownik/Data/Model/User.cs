using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ofertownik.Data.Model
{
    public class User : IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string NIP { get; set; }
    }
}
