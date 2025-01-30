using BookStore.App.Data;
using BookStore.App.Data.Emities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Pages.MyBooks;

public class IndexModel : PageModel
{
    public IList<Book> Books { get;set; }
    private readonly BookDbContext _ctx;

    public IndexModel(BookDbContext context)
    {
        _ctx = context;
    }


    public async Task OnGetAsync()
    {
        Books = await _ctx.Books.ToListAsync();
    }
}
