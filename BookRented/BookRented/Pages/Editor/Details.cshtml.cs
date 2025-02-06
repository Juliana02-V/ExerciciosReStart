namespace BookRented.Pages.Editor
{
    public class DetailsModel : PageModel
    {
        private readonly BookRented.Data.BookDbContext _context;

        public DetailsModel(BookRented.Data.BookDbContext context)
        {
            _context = context;
        }

        public Data.Entities.Editor Edithor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edithor = await _context.Editor.FirstOrDefaultAsync(m => m.Id == id);

            if (edithor is not null)
            {
                Edithor = edithor;

                return Page();
            }

            return NotFound();
        }
    }
}
