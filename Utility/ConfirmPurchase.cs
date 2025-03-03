namespace MvcMovie.Utility;

public class ConfirmPurchase
{
    public int ProductId { get; set; }
    public double Total { get; set; }
    public decimal Unit { get; set; }
    public double Deposit { get; set; }
    public double Discount { get; set; }
    public double Cost { get; set; }
    public int SupplierId { get; set; }
    public int UnitTypeId { get; set; }

}