namespace BookRented.Data.Entities;

public class Book
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Isbn { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    public string Category { get; set; }

    
    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public int EditorId { get; set; }
    public Editor Editor { get; set; }


}
