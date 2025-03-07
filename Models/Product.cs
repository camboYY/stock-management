using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcMovie.Models
{
    public class Product
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Title { get; set; }
        public string? Description { set; get; }
        [Required]
        public string ISBN { set; get; }
        [Required]
        public string Author { set; get; }
        [Display(Name = "Cost")]
        [Range(1, 1000)]
        public double Cost { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }
        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        [Display(Name = "Image")]
        public string? ImageUrl { set; get; }
        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Quantity On Hand")]
        public double QtyOnHand { get; set; }
        [Display(Name = "Quantity Alert")]
        public int QtyAlert { get; set; }
        [Display(Name = "Stock Type")]
        public string? StockType { get; set; }
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [ValidateNever]
        public Branch Branch { get; set; }
        [Display(Name = "Warehouse")]
        public int WarehouseId { get; set; }
        [ValidateNever]
        public Warehouse Warehouse { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        [ValidateNever]
        public Supplier Supplier { get; set; }

    }
}