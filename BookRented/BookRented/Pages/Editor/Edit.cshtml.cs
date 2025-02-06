namespace BookRented.Pages.Editor;

public class EditModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public EditModel(BookRented.Data.BookDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Data.Entities.Editor Edithor { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var edithor =  await _context.Editor.FirstOrDefaultAsync(m => m.Id == id);
        if (edithor == null)
        {
            return NotFound();
        }
        Edithor = edithor;
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

        _context.Attach(Edithor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EdithorExists(Edithor.Id))
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

    private bool EdithorExists(int id)
    {
        return _context.Editor.Any(e => e.Id == id);
    }
}
