namespace BrainWareCore.Models
{
    /// <summary>
    /// OrderProduct model 
    /// </summary>
    public class OrderProduct : IOrderProduct
    {
        /// <summary>
        /// Order Id 
        /// </summary>
        public int orderId { get; set; }
        /// <summary>
        /// Product Id
        /// </summary>
        public int productId { get; set; }
        /// <summary>
        /// Quantity of Product for the Order
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// Price of the Product for the Order
        /// </summary>
        public decimal price { get; set; }
    }
}
