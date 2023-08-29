using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reviews.data;

[Table("Authors")]
public class Author
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(128)]
    public string? Name { get; set; }

    public IList<Review> Reviews { get; set; } = new List<Review>();
}