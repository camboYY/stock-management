using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : IdentityDbContext<IdentityUser>
    {

        public MvcMovieContext(DbContextOptions<MvcMovieContext> options) : base(options)
        {
        }


        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<OtherExpenseType> OtherExpenseTypes { get; set; }
        public DbSet<OtherIncomeType> OtherIncomeTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<PurchasePayment> PurchasePayments { get; set; }

        public DbSet<Rate> Rates { get; set; } 


        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Title).HasColumnType("TEXT");
                entity.Property(e => e.Genre).HasColumnType("TEXT");
            });
            modelBuilder.Entity<Category>().ToTable("Category").HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Customer>().ToTable("Customers").HasData(
                new Customer { Id = 1, Name = "Joker", Sex = Gender.Female, Address = "#12, st:30, sangkat vealvong, khan 7 makra, phnom penh", PhoneNumber = "0973333333", Image = "" },
                new Customer { Id = 2, Name = "Later", Sex = Gender.Male, Address = "#13, st:33, sangkat vealvong, khan 7 makra, phnom penh", PhoneNumber = "0636363", Image = "" },
                new Customer { Id = 3, Name = "Absent", Sex = Gender.Female, Address = "#12, st:44, sangkat vealvong, khan 7 makra, phnom penh", PhoneNumber = "8947474", Image = "" }
            );
            modelBuilder.Entity<OtherExpenseType>().ToTable("OtherExpenseTypes").HasData(
                new OtherExpenseType { Id = 1, Name = "Salary expense" },
                new OtherExpenseType { Id = 2, Name = "Interest expense" },
                new OtherExpenseType { Id = 3, Name = "Fee expense" }
                );
            modelBuilder.Entity<OtherIncomeType>().ToTable("OtherIncomeTypes").HasData(
                new OtherIncomeType { Id = 1, Name = "Other incomes" },
                new OtherIncomeType { Id = 2, Name = "Interest income" },
                new OtherIncomeType { Id = 3, Name = "Fee income" }
            );
            modelBuilder.Entity<Branch>().ToTable("Branches").HasData(
                new Branch { Id = 1, Name = "Phnom Penh", BranchCode = "0001", Active = true },
                new Branch { Id = 2, Name = "Battambang", BranchCode = "0002", Active = true },
                new Branch { Id = 3, Name = "Kampot", BranchCode = "0003", Active = true }
                );
            modelBuilder.Entity<Supplier>().ToTable("Suppliers").HasData(
                new Supplier { Id = 1, Name = "Yaksar", ContactName = "Toto", PhoneNumber = "089333444", Address = "1234 Pine St, Los Angeles, California, 90210, United States" },
                new Supplier { Id = 2, Name = "Krong Thai", ContactName = "Tata", PhoneNumber = "098333334", Address = "5678 Oak Ave, New York, New York, 10001, United States" },
                new Supplier { Id = 3, Name = "Appsora", ContactName = "KOKO", PhoneNumber = "078736363", Address = "5678 Oak Ave, New York, New York, 10001, Phnom Penh" }
                );
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods").HasData(
            new PaymentMethod { Id = 1, Name = "ABA Pay", Type = "Toto", Status = true },
            new PaymentMethod { Id = 2, Name = "Bangkok Pay", Type = "Tata", Status = true },
            new PaymentMethod { Id = 3, Name = "Wing Pay", Type = "KOKO", Status = true },
            new PaymentMethod { Id = 4, Name = "Cash", Type = "KOKO", Status = true }

            );
            modelBuilder.Entity<Warehouse>().ToTable("Warehouses").HasData(
                new Warehouse { Id = 1, Name = "Yaksar", Active = true },
                new Warehouse { Id = 2, Name = "Krong Thai", Active = true },
                new Warehouse { Id = 3, Name = "Appsora", Active = true }
                );
            modelBuilder.Entity<Product>().ToTable("Product").HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1,
                    ImageUrl = "",
                    StockType = "ABC",
                    QtyAlert = 1,
                    SupplierId = 1,
                    BranchId = 1,
                    QtyOnHand = 90,
                    WarehouseId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = "",
                    StockType = "ABD",
                    QtyAlert = 1,
                    SupplierId = 2,
                    BranchId = 1,
                    QtyOnHand = 100,
                    WarehouseId = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2,
                    ImageUrl = "",
                    StockType = "ABE",
                    QtyAlert = 1,
                    SupplierId = 1,
                    BranchId = 2,
                    QtyOnHand = 90,
                    WarehouseId = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 3,
                    ImageUrl = "",
                    StockType = "CBC",
                    QtyAlert = 1,
                    SupplierId = 2,
                    BranchId = 2,
                    QtyOnHand = 90,
                    WarehouseId = 2
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = "",
                    StockType = "AEC",
                    QtyAlert = 1,
                    SupplierId = 2,
                    BranchId = 3,
                    QtyOnHand = 90,
                    WarehouseId = 3
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 2,
                    ImageUrl = "",
                    StockType = "GBC",
                    QtyAlert = 1,
                    SupplierId = 3,
                    BranchId = 3,
                    QtyOnHand = 90,
                    WarehouseId = 3
                }
                );
            modelBuilder.Entity<UnitType>().ToTable("UnitTypes").HasData(
                new UnitType { Id = 1, Name = "ABC", Qty = 100 },
                new UnitType { Id = 2, Name = "CDB Thai", Qty = 200 },
                new UnitType { Id = 3, Name = "CCD", Qty = 900 }
            );
            modelBuilder.Entity<ProductUnit>().ToTable("ProductUnits").HasData(
                new ProductUnit { Id = 1, ProductId = 1, UnitTypeId = 1, Cost = 90, Price = 100, IsDefault = true },
                new ProductUnit { Id = 2, ProductId = 1, UnitTypeId = 2, Cost = 10, Price = 40, IsDefault = false },
                new ProductUnit { Id = 3, ProductId = 1, UnitTypeId = 3, Cost = 30, Price = 40, IsDefault = false }
            );
            modelBuilder.Entity<Purchase>().ToTable("Purchases").HasData(
               new Purchase { Id = 1, PurchaseDate = DateTime.Today, Date = DateTime.Now, UserId1 = "three", SupplierId = 1, Amount = 100.0, Discount = 10, Deposit = 10, Status = true },
               new Purchase { Id = 2, PurchaseDate = DateTime.Today, Date = DateTime.Now, UserId1 = "one", SupplierId = 2, Amount = 300.0, Discount = 30, Deposit = 30, Status = true },
               new Purchase { Id = 3, PurchaseDate = DateTime.Today, Date = DateTime.Now, UserId1 = "two", SupplierId = 3, Amount = 200.0, Discount = 10, Deposit = 10, Status = true }
           );
            modelBuilder.Entity<PurchaseDetail>().ToTable("PurchaseDetails").HasData(
                new PurchaseDetail { Id = 1, PurchaseId = 1, ProductId = 1, Cost = 100.0, Discount = 10, Qty = 100, UnitTypeId = 1 },
                new PurchaseDetail { Id = 2, PurchaseId = 2, ProductId = 2, Cost = 300.0, Discount = 30, Qty = 230, UnitTypeId = 2 },
                new PurchaseDetail { Id = 3, PurchaseId = 3, ProductId = 3, Cost = 400.0, Discount = 20, Qty = 200, UnitTypeId = 3 }
            );

            modelBuilder.Entity<PurchasePayment>().ToTable("PurchasePayments").HasData(
                new PurchasePayment { Id = 1, PurchaseId = 1, PaymentMethodId = 1, PayAmount = 100.0, PayDate = DateTime.Now },
                new PurchasePayment { Id = 2, PurchaseId = 2, PaymentMethodId = 2, PayAmount = 200.0, PayDate = DateTime.Now },
                new PurchasePayment { Id = 3, PurchaseId = 3, PaymentMethodId = 1, PayAmount = 300.0, PayDate = DateTime.Now }
            );
        }
    }



}
