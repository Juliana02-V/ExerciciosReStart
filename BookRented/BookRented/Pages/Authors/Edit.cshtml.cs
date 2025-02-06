namespace BookRented.Pages.Authors;

public class EditModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public EditModel(BookRented.Data.BookDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Author Author { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author =  await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);
        if (author == null)
        {
            return NotFound();
        }
        Author = author;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Author).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AuthorExists(Author.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool AuthorExists(int id)
    {
        return _context.Authors.Any(e => e.Id == id);
    }
}
