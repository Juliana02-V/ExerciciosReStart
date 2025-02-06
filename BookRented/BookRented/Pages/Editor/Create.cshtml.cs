namespace BookRented.Pages.Editor;

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
    public Data.Entities.Editor Edithor { get; set; } = default!;

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Editor.Add(Edithor);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
