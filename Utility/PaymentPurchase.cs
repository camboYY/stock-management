using Microsoft.Build.Framework;

namespace MvcMovie.Utility;

public class PaymentPurchase
{
    [Required]
    public string UserId { get; set; }

    [Required]
    public int PurchaseId { get; set; }
    [Required]
    public int PaymentMethodId { get; set; }
    [Required]
    public DateTime PayDate { get; set; }
    [Required]
    public double PayAmount { get; set; }

}