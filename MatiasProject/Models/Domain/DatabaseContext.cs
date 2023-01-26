using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MatiasProject.Models.Domain
{
    public class DatabaseContext:IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }

        public DbSet<Gatunek> Gatunek { get; set;}
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Wydawnictwo> Wydawnictwo { get; set; }
        public DbSet<Book> Book { get; set; }   
    }
}
