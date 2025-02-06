﻿namespace BookRented.Pages.MyBooks;

public class DeleteModel : PageModel
{
    private readonly BookRented.Data.BookDbContext _context;

    public DeleteModel(BookRented.Data.BookDbContext context)
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

        var book = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);

        if (book is not null)
        {
            Book = book;

            return Page();
        }

        return NotFound();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            Book = book;
            _context.Books.Remove(Book);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
