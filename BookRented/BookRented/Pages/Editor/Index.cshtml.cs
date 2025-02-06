namespace BookRented.Pages.Editor;

public class IndexModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public IndexModel(BookRented.Data.BookDbContext context)
    {
        _context = context;
    }

    public IList<Data.Entities.Editor> Edithor { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Edithor = await _context.Editor.ToListAsync();
    }
}
