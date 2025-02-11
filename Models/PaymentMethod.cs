using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class PaymentMethod
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Payment Name")]
    public string Name { get; set; }
    [DisplayName("Payment Type")]
    public string Type { get; set; }
    public bool Status { get; set; }
}