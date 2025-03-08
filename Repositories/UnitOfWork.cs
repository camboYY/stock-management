using MvcMovie.Controllers;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public MvcMovieContext _db { get; set; }
        public IProductRepository Product { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IBranchRepository Branch { get; set; }
        public ISupplierRepository Supplier { get; set; }
        public IWarehouseRepository Warehouse { get; set; }
        public IProductUnitRepository ProductUnit { get; set; }
        public IUnitTypeRepository UnitType { get; set; }
        public IPaymentMethodRepository PaymentMethod { get; set; }
        public IOtherIncomeTypeRepository OtherIncomeType { get; set; }
        public IOtherExpenseTypeRepository OtherExpenseType { get; set; }
        public ICustomerRepository Customer { get; set; }
        public IPurchaseDetailRepository PurchaseDetail { get; set; }
        public IPurchasePaymentRepository PurchasePayment { get; set; }
        public IPurchaseRepository Purchase { get; set; }
        public ISaleDetailRepository SaleDetail { get; set; }
        public ISalePaymentRepository SalePayment { get; set; }
        public ISaleRepository Sale { get; set; }


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
            OtherExpenseType = new OtherExpenseTypeRepository(_db);
            OtherIncomeType = new OtherIncomeTypeRepository(_db);
            Customer = new CustomerRepository(_db);
            PurchaseDetail = new PurchaseDetailRepository(_db);
            PurchasePayment = new PurchasePaymentRepository(_db);
            Purchase = new PurchaseRepository(_db);
            SaleDetail = new SaleDetailRepository(_db);
            SalePayment = new SalePaymentRepository(_db);
            Sale = new SaleRepository(_db);
           
        }

        public void save()
        {
            _db.SaveChanges();
        }


        public void Dispose()
        {
            _db.Dispose();
        }
    }
}