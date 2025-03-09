namespace MvcMovie.Utility;

public class SaleDTO
{
    public double sumDeposit { get; set; }
    public double sumPrice { get; set; }// sum price . for amount field
    public double sumDiscount { get; set; }
    public double sumTotal { get; set; }
    public int CustomerId { get; set; }
    public DateTime SaleDate { get; set; }

    public int RateId { set; get; }
    public bool Status { get; set; }

}