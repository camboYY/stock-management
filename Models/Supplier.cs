using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Supplier
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Supplier Name")]
    public string Name { get; set; }
    [DisplayName("Contact Person")]
    public string ContactName { get; set; }
    [Required]
    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; }
    [Required]
    public string Address { get; set; }
    public ICollection<Product> Products { get; } = new List<Product>(); // Collection navigation containing dependents

}