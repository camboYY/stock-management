using NuGet.Common;

namespace MvcMovie.Utility;

public class ConfirmSale
{
    public int ProductId { get; set; }
    public double Total { get; set; }
    public double Unit { get; set; } // qty
    public double Discount { get; set; }
    public double Cost { get; set; }
    public double Price { get; set; }
    public int UnitTypeId { get; set; }

}