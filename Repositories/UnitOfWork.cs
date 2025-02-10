using MvcMovie.Controllers;
using MvcMovie.Data;

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


        public UnitOfWork(MvcMovieContext db)
        {
            _db = db;
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db);
            Branch = new BranchRepository(_db);
            Supplier = new SupplierRepository(_db);
            Warehouse = new WarehouseRepository(_db);
        }

        public void save()
        {
            _db.SaveChanges();
        }
    }
}