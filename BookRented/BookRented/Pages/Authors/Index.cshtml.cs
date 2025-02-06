namespace BookRented.Pages.Authors;

public class IndexModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public IndexModel(BookRented.Data.BookDbContext context)
    {
        _context = context;
    }

    public IList<Author> Author { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Author = await _context.Authors.ToListAsync();
    }
}
