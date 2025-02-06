

namespace BookRented.Pages.MyBooks
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }

        private readonly BookRepository _bookRepository;

        private readonly BookDbContext _context;

        public CreateModel(BookDbContext context, BookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;

        }

        public IActionResult OnGet()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["EditorId"] = new SelectList(_context.Editor, "Id", "Name");

            return Page();
        }



        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
