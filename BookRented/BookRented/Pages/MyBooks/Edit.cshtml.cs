namespace BookRented.Pages.MyBooks;
public class EditModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public EditModel(BookRented.Data.BookDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var book =  await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        Book = book;
       ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
       ViewData["EditorId"] = new SelectList(_context.Editor, "Id", "Name");
       ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
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

        _context.Attach(Book).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookExists(Book.Id))
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

    private bool BookExists(int id)
    {
        return _context.Books.Any(e => e.Id == id);
    }
}
