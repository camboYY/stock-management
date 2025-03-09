using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }
    public DateTime SaleDate { get; set; }
    public DateTime Date { get; set; }
    [DisplayName("Prepared By")]
    public string PreparedBy { get; set; } // PreparedBy this is userId
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }
    [DisplayName("Customer")]
    public int CustomerId { get; set; }
    [ValidateNever]
    public Customer Customer { get; set; }
    public double Amount { get; set; }
    public double Discount { get; set; }
    public double Deposit { get; set; }
    public long InvoiceNumber { get; set; }
    public bool Status { get; set; }
    [DisplayName("Sale Rate")]
    public int RateId { get; set; }
    [ValidateNever]
    public Rate Rate { get; set; }
}