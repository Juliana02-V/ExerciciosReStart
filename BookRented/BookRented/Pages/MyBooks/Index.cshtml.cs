namespace BookRented.Pages.MyBooks;

public class IndexModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public IndexModel(BookRented.Data.BookDbContext context)
    {
        _context = context;
    }

    public IList<Book> Book { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await _context.Books
            .Include(b => b.Author)
            .Include(b => b.Editor)
            .Include(b => b.User).ToListAsync();
    }
}
