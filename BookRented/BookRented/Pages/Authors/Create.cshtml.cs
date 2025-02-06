namespace BookRented.Pages.Authors;

public class CreateModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public CreateModel(BookRented.Data.BookDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Author Author { get; set; } = default!;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Authors.Add(Author);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
