using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.App.Data;
using BookStore.App.Data.Emities;
using System.Security.Claims;

namespace BookStore.App.Pages.MyBooks
{
    public class CreateModel : PageModel
    {
        private readonly BookStore.App.Data.BookDbContext _context;

        public CreateModel(BookStore.App.Data.BookDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Book.UserId");
            ModelState.Remove("Book.Isbn");

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Book.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.Books.Add(Book);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
