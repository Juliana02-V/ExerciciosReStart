namespace BookRented.Data.Entities;

public class Editor
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

}
