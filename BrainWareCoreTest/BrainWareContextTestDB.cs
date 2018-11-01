using BrainWareCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BrainWareCoreTest
{
    // Note that there is currently an outstanding issue with the in memory EF database. 
    // The autoincrement is shared accross instances and not reset, so ids cannot be relied upon.
    //https://github.com/aspnet/EntityFrameworkCore/issues/6872
    public static class BrainWareContextTestDB
    {
        public static BrainWareContext GetContext()
        {
            DbContextOptions<BrainWareContext> contextOptions = new DbContextOptionsBuilder<BrainWareContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new BrainWareContext(contextOptions);
        }

        public static void InitializeMockData(BrainWareContext db)
        {
            if (db.Company.CountAsync().GetAwaiter().GetResult() == 0)
            {
                // Add Companies
                Company[] companies =
                {
                    new Company() { Name = "Test Company 1" },
                    new Company() { Name = "Test Company 2" },
                    new Company() { Name = "Test Company 3" },
                    new Company() { Name = "Test Company 4" },
                    new Company() { Name = "Test Company 5" }
                };
                db.Company.AddRange(companies);
                db.SaveChanges();

                // Add Products
                Product[] products =
                {
                    new Product() { Name = "Test Product 1", Price = 1 },
                    new Product() { Name = "Test Product 2", Price = 2 },
                    new Product() { Name = "Test Product 3", Price = 3 },
                    new Product() { Name = "Test Product 4", Price = 4 },
                    new Product() { Name = "Test Product 5", Price = 5 }
                };
                db.Product.AddRange(products);
                db.SaveChanges();

                // Add Orders
                foreach (Company c in companies)
                {
                    db.Order.Add(new Order() { Description = $"Order {c.CompanyId.ToString()}", CompanyId = c.CompanyId });
                }
                db.SaveChanges();

                // Add Order Products
                foreach (Order o in db.Order)
                {
                    foreach(Product p in db.Product)
                    {
                        db.Orderproduct.Add(new Orderproduct() { OrderId = o.OrderId, ProductId = p.ProductId, Quantity = p.ProductId, Price = p.ProductId });
                    }
                }
                db.SaveChanges();
            }
        }

    }
}
