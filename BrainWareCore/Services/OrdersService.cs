using BrainWareCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BrainWareCore.Services
{
    /// <summary>
    /// Handles information requests for Orders
    /// </summary>
    public class OrdersService : IOrdersService
    {
        private readonly Data.BrainWareContext db;
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="dbContext"></param>
        public OrdersService(Data.BrainWareContext dbContext)
        {
            db = dbContext;
        }
        /// <summary>
        /// Gets a Heirarchical list of Orders for the specified Company
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>List of Orders</returns>
        public List<Order> GetOrdersByCompany(int id)
        {
            List<Order> orderData =
                    (from company in db.Company
                     join order in db.Order on company.CompanyId equals order.CompanyId
                     where company.CompanyId == id
                     select new Order()
                     {
                         company = new Company() {
                             companyId = company.CompanyId,
                             name = company.Name
                         },
                         description = order.Description,
                         orderId = order.OrderId,
                     }).ToList();

            List<OrderProduct> orderproductData =
                (from orderproduct in db.Orderproduct
                 join order in db.Order on orderproduct.OrderId equals order.OrderId
                 join product in db.Product on orderproduct.ProductId equals product.ProductId
                 where order.CompanyId == id
                 select new OrderProduct()
                 {
                     orderId = orderproduct.OrderId,
                     productId = orderproduct.ProductId,
                     price = orderproduct.Price ?? 0,
                     quantity = orderproduct.Quantity
                 }).ToList();

            foreach (Order o in orderData)
            {
                o.orderProducts = orderproductData.Where(opd => opd.orderId == o.orderId).ToList();
                if (o.orderProducts != null && o.orderProducts.Count > 0)
                {
                    foreach (OrderProduct op in o.orderProducts)
                    {
                        o.orderTotal += op.quantity * op.price;
                    }
                }
            }
            return orderData;
        }
        /// <summary>
        /// Gets a Flattened list of Order Details for the specified Company
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>List of Order Details</returns>
        public List<OrderDetails> GetOrderDetailsByCompany(int id)
        {
            int rowIndex = 1;
            List<OrderDetails> ods = (from company in db.Company
                    join order in db.Order on company.CompanyId equals order.CompanyId
                    join orderproduct in db.Orderproduct on order.OrderId equals orderproduct.OrderId
                    join product in db.Product on orderproduct.ProductId equals product.ProductId
                    where order.CompanyId == id
                    select new OrderDetails()
                    {
                        companyId = company.CompanyId,
                        companyName = company.Name,
                        orderId = order.OrderId,
                        orderDescription = order.Description,
                        orderproductPrice = orderproduct.Price ?? 0,
                        orderproductQuantity = orderproduct.Quantity,
                        orderproductTotalPrice = ((orderproduct.Price ?? 0) * orderproduct.Quantity),
                        productId = product.ProductId,
                        productName = product.Name
                    }).ToList();
            ods.ForEach(od => od.index = rowIndex++);
            return ods;
        }
    }
}
