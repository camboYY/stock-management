using MvcMovie.Models;

namespace  MvcMovie.Models {
public class SaleViewModel
{
    public List<Product> SelectedProducts { get; set; } = new List<Product>();
    public int CustomerId { get; set; }
    public double Deposit { get; set; }
}
}