using MvcMovie.Controllers;

namespace MvcMovie.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IBranchRepository Branch { get; }
        ISupplierRepository Supplier { get; }
        IWarehouseRepository Warehouse { get; }
        IProductUnitRepository ProductUnit { get; }
        IUnitTypeRepository UnitType { get; }
        IPaymentMethodRepository PaymentMethod { get; }
        IOtherExpenseTypeRepository OtherExpenseType { get; }
        IOtherIncomeTypeRepository OtherIncomeType { get; }
        ICustomerRepository Customer { get; }

        void save();
    }

}