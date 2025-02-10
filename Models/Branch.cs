using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Branch
{
    [Key]
    public int Id { set; get; }
    [Required]
    [DisplayName("Branch Name")]
    public string Name { get; set; }
    [DisplayName("Branch Code")]
    public string BranchCode { get; set; }
    public bool Active { set; get; }
    public ICollection<Product> Products { get; } = new List<Product>(); // Collection navigation containing dependents

}