namespace BookRented.Pages.Authors;

public class DetailsModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public DetailsModel(BookRented.Data.BookDbContext context)
    {
        _context = context;
    }

    public Author Author { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

        if (author is not null)
        {
            Author = author;

            return Page();
        }

        return NotFound();
    }
}
