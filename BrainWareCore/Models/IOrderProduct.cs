namespace BrainWareCore.Models
{
    /// <summary>
    /// Interface for the OrderProduct model 
    /// </summary>
    public interface IOrderProduct
    {
        /// <summary>
        /// Order Id 
        /// </summary>
        int orderId { get; set; }
        /// <summary>
        /// Product Id
        /// </summary>
        int productId { get; set; }
        /// <summary>
        /// Quantity of Product for the Order
        /// </summary>
        int quantity { get; set; }
        /// <summary>
        /// Price of the Product for the Order
        /// </summary>
        decimal price { get; set; }
    }
}
