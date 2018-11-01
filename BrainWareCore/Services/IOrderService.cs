using BrainWareCore.Models;

namespace BrainWareCore.Services
{
    /// <summary>
    /// Handles CRUD operations for the Order entity
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="o">Order to Create</param>
        /// <returns>Order created</returns>
        IOrder Create(IOrder o);
        /// <summary>
        /// Reads an existing Order
        /// </summary>
        /// <param name="id">Id of the Order</param>
        /// <returns>The Order read</returns>
        IOrder Read(int id);
        /// <summary>
        /// Updates an existing Order
        /// </summary>
        /// <param name="o">Order to Update</param>
        /// <returns>Id of the Order Updated</returns>
        int Update(IOrder o);
        /// <summary>
        /// Deletes an Existing Order
        /// </summary>
        /// <param name="id">Id of the Order to Delete</param>
        /// <returns>Id of the Order Deleted</returns>
        int Delete(int id);
    }
}
