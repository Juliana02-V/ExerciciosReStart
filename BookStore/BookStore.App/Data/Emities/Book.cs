namespace BookStore.App.Data.Emities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Isbn { get; set; }
    public string Category { get; set; }
    public string Publisher { get; set; }
    public DateTime PublisheAt { get; set; }
}
