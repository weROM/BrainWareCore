using System.Collections.Generic;

namespace BrainWareCore.Models
{
    /// <summary>
    /// Model representing an Order
    /// </summary>
    public class Order : IOrder
    {
        /// <summary>
        /// Id of the Order
        /// </summary>
        public int orderId { get; set; }
        /// <summary>
        /// Company that the Order is for
        /// </summary>
        public Company company { get; set; }
        /// <summary>
        /// Description of the Order
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Dollar total for the Order
        /// </summary>
        public decimal orderTotal { get; set; }
        /// <summary>
        /// List of OrderProducts for the Order
        /// </summary>
        public List<OrderProduct> orderProducts { get; set; }
    }
}
