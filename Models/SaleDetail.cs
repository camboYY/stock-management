
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class SaleDetail
{
    [Key]
    public int Id { set; get; }

    public int SaleId { get; set; }
    [ValidateNever]
    public Sale Sale { get; set; }

    public int ProductId { get; set; }
    [ValidateNever]
    public Product Product { get; set; }

    public int UnitTypeId { get; set; }
    [ValidateNever]
    public UnitType UnitType { get; set; }

    public double Cost { get; set; }
    public double Price { get; set; }
    public double Qty { get; set; }
    public double Discount { get; set; }
}