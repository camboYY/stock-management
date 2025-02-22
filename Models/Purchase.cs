using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models;

public class Purchase
{
    [Key]
    public int Id { set; get; }
    [Required]
    public DateTime? PurchaseDate { get; set; }
    public DateTime? Date { get; set; }
    [DisplayName("Purchased By")]
    public int UserId { get; set; }
    [ValidateNever]
    public ApplicationUser User { get; set; }
    [DisplayName("Supplier Name")]
    public int SupplierId { get; set; }
    [ValidateNever]
    public Supplier Supplier { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public double Amount { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public double Discount { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public double Deposit { get; set; }
    public bool Status { get; set; }
    public string? PurchaseOrderNumber { get; set; }
}