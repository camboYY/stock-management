using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class OtherIncomeType
{
    [Key]
    public int Id { get; set; }
    [DisplayName("Other Income Type")]
    public string Name { get; set; }
}