using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class OtherExpenseType
{
    [Key]
    public int Id { get; set; }
    [DisplayName("Other Expense Type")]
    public string Name { get; set; }
}