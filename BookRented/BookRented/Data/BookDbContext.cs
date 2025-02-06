using BookRented.Data.Entities;

namespace BookRented.Data;

public class BookDbContext : IdentityDbContext 
{
  public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Edithor> Edithors { get; set; }

}
