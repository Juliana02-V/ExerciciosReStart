using BoookStore_Juliana_Vaz.App.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoookStore_Juliana_Vaz.App.Data
{
    public class BookDbContext : IdentityDbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
       

        
    }
}
