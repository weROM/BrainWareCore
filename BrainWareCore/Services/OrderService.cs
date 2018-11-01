using BrainWareCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BrainWareCore.Services
{
    /// <summary>
    /// Handles operations for the Order entity
    /// </summary>
    public class OrderService : IOrderService 
    {
        private readonly Data.BrainWareContext db;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">EF context for the Order entity</param>
        public OrderService(Data.BrainWareContext dbContext)
        {
            db = dbContext;
        }
        /// <summary>
        /// Creates a new Order.
        /// - Adds the Order
        /// - Reads the Order by id from EF
        /// </summary>
        /// <param name="o">Order to create</param>
        /// <returns>The Order created</returns>
        public IOrder Create(IOrder o)
        {
            Data.Order orderData = new Data.Order
            {
                CompanyId = o.company?.companyId ?? 0,
                Description = o.description,
                Orderproduct = o.orderProducts?
                                        .Select(op =>
                                            new Data.Orderproduct()
                                            {
                                                ProductId = op.productId,
                                                Price = op.price,
                                                Quantity = op.quantity
                                            }).ToArray()
            };

            db.Add(orderData);
            db.SaveChanges();

            return Read(orderData.OrderId);
        }
        /// <summary>
        /// Reads the Order by id from EF
        /// - Calculates the total amount for the order
        /// </summary>
        /// <param name="id">Id of the Order</param>
        /// <returns>The Order if it exists, null if not</returns>
        public IOrder Read(int id)
        {
            Data.Order o = GetOrderData(id);
            if (o != null)
            {
                Order order = new Order()
                {
                    orderId = o.OrderId,
                    company = new Company()
                    {
                        companyId = o.CompanyId,
                        name = o.Company?.Name
                    },
                    description = o.Description,
                    orderProducts = GetOrderProductData(id)
                                        .Select(op =>
                                            new OrderProduct()
                                            {
                                                orderId = op.OrderId,
                                                price = op.Price ?? 0,
                                                productId = op.ProductId,
                                                quantity = op.Quantity
                                            }).ToList()
                };

                if (order != null)
                {
                    foreach (OrderProduct op in order.orderProducts)
                    {
                        order.orderTotal += op.price * op.quantity;
                    }
                }
                return order;
            }
            return null;
        }
        /// <summary>
        /// Updates the Order passed in
        /// </summary>
        /// <param name="o">Order to update</param>
        /// <returns>Id of the Order updated if it exists, Invalid Id if not</returns>
        public int Update(IOrder o)
        {
            Data.Order OrderData = GetOrderData(o.orderId);
            if (OrderData != null)
            {
                OrderData.OrderId = o.orderId;
                OrderData.CompanyId = o.company?.companyId ?? 0;
                OrderData.Description = o.description;
                OrderData.Orderproduct = o.orderProducts?
                                            .Select(op =>
                                                new Data.Orderproduct()
                                                {
                                                    OrderId = o.orderId,
                                                    ProductId = op.productId,
                                                    Price = op.price,
                                                    Quantity = op.quantity
                                                }).ToArray();

                db.SaveChanges();

                return o.orderId;
            }
            return Constants.InvalidId;
        }
        /// <summary>
        /// Deletes the Order specified by the id
        /// </summary>
        /// <param name="id">Id of the Order to delete</param>
        /// <returns>Id of the Order deleted if it exists, Invalid Id if not</returns>
        public int Delete(int id)
        {
            Data.Order OrderData = GetOrderData(id);
            if (OrderData != null)
            {
                db.Remove(OrderData);
                db.SaveChanges();
                return id;
            }
            return Constants.InvalidId;
        }
        /// <summary>
        /// Gets the Order from EF for the Order id specified
        /// </summary>
        /// <param name="id">Id of the Order</param>
        /// <returns>EF Order if it exists, null if it does not</returns>
        private Data.Order GetOrderData(int id)
        {
            return (from order in db.Order
                    where order.OrderId == id
                    select order).FirstOrDefault();
        }
        /// <summary>
        /// Gets a list of Orderproducts from EF for the Order id specified
        /// </summary>
        /// <param name="id">Id of the Order</param>
        /// <returns>List of EF Orderproducts</returns>
        private List<Data.Orderproduct> GetOrderProductData(int id)
        {
            return (from orderProduct in db.Orderproduct
                    where orderProduct.OrderId == id
                    select orderProduct).ToList();
        }
    }
}
