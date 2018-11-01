using BrainWareCore.Models;
using System.Collections.Generic;

namespace BrainWareCore.Services
{
    /// <summary>
    /// Handles information requests for Orders
    /// </summary>
    public interface IOrdersService
    {
        /// <summary>
        /// Gets a Heirarchical list of Orders for the specified Company
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>List of Orders</returns>
        List<Order> GetOrdersByCompany(int id);
        /// <summary>
        /// Gets a Flattened list of Order Details for the specified Company
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>List of Order Details</returns>
        List<OrderDetails> GetOrderDetailsByCompany(int id);
    }
}
