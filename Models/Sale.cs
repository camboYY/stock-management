using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }
    public DateTime SaleDate { get; set; }
    public DateTime Date { get; set; }
    public int PreparedBy { get; set; } // PreparedBy this is userId
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }
    public int CustomerId { get; set; }
    [ValidateNever]
    public Customer Customer { get; set; }
    public double Amount { get; set; }
    public double Discount { get; set; }
    public double Deposit { get; set; }
    public int WarehouseId { get; set; }
    [ValidateNever]
    public Warehouse Warehouse { get; set; }
    public int InvoiceNumber { get; set; }
    public bool Status { get; set; }
    public int RateId { get; set; }

}