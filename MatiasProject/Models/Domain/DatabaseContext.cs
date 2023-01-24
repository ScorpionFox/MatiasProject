using Microsoft.EntityFrameworkCore;

namespace MatiasProject.Models.Domain
{
    public class DatabaseContext:DbContext
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
