using Microsoft.EntityFrameworkCore;

namespace BoookStore_Juliana_Vaz.App.Data
{
    public class IdentityDbContext
    {
        private DbContextOptions<BookDbContext> options;

        public IdentityDbContext(DbContextOptions<BookDbContext> options)
        {
            this.options = options;
        }
    }
}