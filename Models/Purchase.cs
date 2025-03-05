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

    [DisplayName("Prepared By")]
    public string? UserId1 { get; set; }  // Nullable to avoid migration errors
    public ApplicationUser User { get; set; }  // Reference to Identity User

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
    [DisplayName("Is Paid")]
    public bool Status { get; set; }
    [DisplayName("Invoice Code")]
    public long? PurchaseOrderNumber { get; set; }
}