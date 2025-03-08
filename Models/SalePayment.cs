using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class SalePayment
{
    [Key]
    public int Id { set; get; }
    public int SaleId { get; set; }
    [ValidateNever]
    public Sale Sale { get; set; }
    public int PaymentMethodId { get; set; }
    [ValidateNever]
    public PaymentMethod PaymentMethod { get; set; }
    public DateTime PayDate { get; set; }
    public double PayAmount { get; set; }
    public int PreparedBy { get; set; }
    [ValidateNever]
    public ApplicationUser User { get; set; }
}