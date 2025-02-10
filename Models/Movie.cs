using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    [DisplayName("Release Date")]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    [Column(TypeName = "decimal(18,4)")] // <--
    public decimal Price { get; set; }
}