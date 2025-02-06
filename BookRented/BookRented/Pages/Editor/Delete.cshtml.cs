namespace BookRented.Pages.Editor
{
    public class DeleteModel : PageModel
    {
        private readonly BookRented.Data.BookDbContext _context;
        public DeleteModel(BookRented.Data.BookDbContext context)
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
            Edithor = await _context.Editor.FirstOrDefaultAsync(m => m.Id == id);
            if (Edithor == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Edithor = await _context.Editor.FindAsync(id);
            if (Edithor != null)
            {
                _context.Editor.Remove(Edithor);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}

