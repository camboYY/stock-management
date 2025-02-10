using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Warehouse
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Warehouse Name")]
    public string Name { get; set; }
    public bool Active { get; set; }
    public ICollection<Product> Products { get; } = new List<Product>(); // Collection navigation containing dependents

}