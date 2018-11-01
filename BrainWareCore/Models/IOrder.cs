using System.Collections.Generic;

namespace BrainWareCore.Models
{
    /// <summary>
    /// Interface for the Order model
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Id of the Order
        /// </summary>
        int orderId { get; set; }
        /// <summary>
        /// Company that the Order is for
        /// </summary>
        Company company { get; set; }
        /// <summary>
        /// Description of the Order
        /// </summary>
        string description { get; set; }
        /// <summary>
        /// Total dollar amount for the order
        /// </summary>
        decimal orderTotal { get; set; }
        /// <summary>
        /// List of OrderProducts attached to the Order
        /// </summary>
        List<OrderProduct> orderProducts { get; set; }
    }
}
