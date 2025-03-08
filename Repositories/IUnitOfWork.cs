using MvcMovie.Controllers;
using MvcMovie.Data;

namespace MvcMovie.Repositories
{
    public interface IUnitOfWork
    {
        MvcMovieContext _db { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IBranchRepository Branch { get; }
        ISupplierRepository Supplier { get; }
        IWarehouseRepository Warehouse { get; }
        IProductUnitRepository ProductUnit { get; }
        IUnitTypeRepository UnitType { get; }
        IPaymentMethodRepository PaymentMethod { get; }

        IRateRepository Rate { get; }
        IOtherExpenseTypeRepository OtherExpenseType { get; }
        IOtherIncomeTypeRepository OtherIncomeType { get; }
        ICustomerRepository Customer { get; }
        IPurchaseDetailRepository PurchaseDetail { get; }
        IPurchasePaymentRepository PurchasePayment { get; }
        IPurchaseRepository Purchase { get; }

        ISaleRepository Sale { get; }

        

        void save();
        void Dispose();
    }

}