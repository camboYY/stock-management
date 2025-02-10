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

        void save();
    }

}