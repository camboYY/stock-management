using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models;

public class PurchasePayment
{
    [Key]
    public int Id { set; get; }

    [DisplayName("Purchase")]
    public int PurchaseId { get; set; }
    [ValidateNever]
    public Purchase Purchase { get; set; }
    [DisplayName("Payment Method")]
    public int PaymentMethodId { get; set; }
    [ValidateNever]
    public PaymentMethod PaymentMethod { get; set; }
    [DisplayName("Payment Date")]
    public DateTime PayDate { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [DisplayName("Payment Amount")]
    public double PayAmount { get; set; }
    [DisplayName("Paid By")]
    [ValidateNever]
    public ApplicationUser User { get; set; }
}