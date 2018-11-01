namespace BrainWareCore.Models
{
    /// <summary>
    /// Flattened (denormalized) details for one row of an order 
    /// </summary>
    public class OrderDetails : IOrderDetails
    {
        /// <summary>
        /// Arbritrary index for the row position within the set of orders that this OrderDetails is a part of
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// Company Id that the Order is for
        /// </summary>
        public int companyId { get; set; }
        /// <summary>
        /// Company Name that the Order is for
        /// </summary>
        public string companyName { get; set; }
        /// <summary>
        /// Id of the Order
        /// </summary>
        public int orderId { get; set; }
        /// <summary>
        /// Description for the Order
        /// </summary>
        public string orderDescription { get; set; }
        /// <summary>
        /// Quantity of the specified Product within this Order
        /// </summary>
        public int orderproductQuantity { get; set; }
        /// <summary>
        /// Unit Price of the specified Product within this Order
        /// </summary>
        public decimal orderproductPrice { get; set; }
        /// <summary>
        /// Total Price of the specified Product within this Order
        /// </summary>
        public decimal orderproductTotalPrice { get; set; }
        /// <summary>
        /// Id of the specified Product within this Order
        /// </summary>
        public int productId { get; set; }
        /// <summary>
        /// Name of the specified Product within this Order
        /// </summary>
        public string productName { get; set; }
    }
}
