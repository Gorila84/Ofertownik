using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ofertownik.Data.Model;

namespace Ofertownik.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CalcullationSetting> CalcullationSettings { get; set; }
    }
}
