using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class UnitType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Qty { get; set; }
}