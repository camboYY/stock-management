using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models;

public class BeginBalance
{
    public int Id { set; get; }
    public DateTime Date { get; set; }
    public int PaymentMethodId { get; set; }
    [ValidateNever]
    public PaymentMethod PaymentMethod { get; set; }
    public double Amount { get; set; }
    public string? Note { get; set; }
    public int PreparedBy { get; set; }
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }
}