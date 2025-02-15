using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Display(Name = "Full Name")]
    public string Name { get; set; }
    [Required]
    [DisplayName("Phone Number")]
    public string? PhoneNumber { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    [Display(Name = "Gender")]
    public Gender Sex { get; set; }
    public string? Image { get; set; }
}