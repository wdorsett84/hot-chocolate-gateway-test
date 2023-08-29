using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace account.data;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(128)]
    public string? Name { get; set; }

    public string? Birthdate { get; set; }

    [Required]
    [MaxLength(128)]
    public string? Username { get; set; }
}