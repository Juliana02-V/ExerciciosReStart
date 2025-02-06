namespace BookRented.Data.Entities;

public class Edithor
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

}
