using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models;

public class ProductUnit
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    [ValidateNever]
    public Product Product { get; set; }
    public int UnitTypeId { get; set; }
    [ValidateNever]
    public UnitType UnitType { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public double Cost { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public double Price { get; set; }
    public bool IsDefault { get; set; }
}