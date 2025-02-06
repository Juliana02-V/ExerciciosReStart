using FluentResults;

namespace BookRented.Data.Repositories;

public class BookRepository
{
    private readonly BookDbContext _ctx;

    public BookRepository(BookDbContext ctx)
    {
        _ctx = ctx;
    }

    public Book GetBookById(int id)
    {
        return _ctx.Books.FirstOrDefault(b => b.Id == id);
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await _ctx.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<Result> UpdateAsync(Book book)
    {
        try
        {
            _ctx.Attach(book).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();

            return Result.Ok();
        }
        catch
        {
            return Result.Fail("Error updating book");
        }
    }

    public async Task<Result> DeleteAsync(int bookId, string userId)
    {
        try
        {
            int res = await _ctx.Books
                .Where(b => b.Id == bookId && b.UserId == userId)
                .ExecuteDeleteAsync();

            return res > 0 ? Result.Ok() : Result.Fail("Book not found");
        }
        catch
        {
            return Result.Fail("Error deleting book");
        }
    }

    public async Task AddAsync(Book book)
    {
        _ctx.Books.Add(book);
        await _ctx.SaveChangesAsync();
    }
}
