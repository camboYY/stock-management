using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models;

public class PurchaseDetail
{
    [Key]
    public int Id { get; set; }
    [DisplayName("Purchase")]
    public int PurchaseId { get; set; }
    [ValidateNever]
    public Purchase Purchase { get; set; }
    [DisplayName("Product")]
    public int ProductId { set; get; }
    [ValidateNever]
    public Product Product { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public double Cost { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public double Discount { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Qty { get; set; }

    public UnitType UnitType { get; set; }
    [ValidateNever]
    public int UnitTypeId { get; set; }
}