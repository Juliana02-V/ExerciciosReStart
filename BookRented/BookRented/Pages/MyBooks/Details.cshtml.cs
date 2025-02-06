namespace BookRented.Pages.MyBooks
{
    public class DetailsModel : PageModel
    {
        private readonly BookRented.Data.BookDbContext _context;

        public DetailsModel(BookRented.Data.BookDbContext context)
        {
            _context = context;
        }

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
    }
}
