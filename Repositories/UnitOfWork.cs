using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MvcMovieContext _db;
        public IProductRepository Product { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IBranchRepository Branch { get; set; }
        public ISupplierRepository Supplier { get; set; }
        public IWarehouseRepository Warehouse { get; set; }
        public IProductUnitRepository ProductUnit { get; set; }
        public IUnitTypeRepository UnitType { get; set; }
        public IPaymentMethodRepository PaymentMethod { get; set; }

        public UnitOfWork(MvcMovieContext db)
        {
            _db = db;
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db);
            Branch = new BranchRepository(_db);
            Supplier = new SupplierRepository(_db);
            Warehouse = new WarehouseRepository(_db);
            ProductUnit = new ProductUnitRepository(_db);
            UnitType = new UnitTypeRepository(_db);
            PaymentMethod = new PaymentMethodRepository(_db);
        }

        public void save()
        {
            _db.SaveChanges();
        }
    }
}