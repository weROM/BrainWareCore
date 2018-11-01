namespace BrainWareCore.Models
{
    /// <summary>
    /// Interface for flattened (denormalized) details for one row of an order 
    /// </summary>
    interface IOrderDetails
    {
        /// <summary>
        /// Arbritrary index for the row position within the set of orders that this OrderDetails is a part of
        /// </summary>
         int index { get; set; }
        /// <summary>
        /// Company Id that the Order is for
        /// </summary>
         int companyId { get; set; }
        /// <summary>
        /// Company Name that the Order is for
        /// </summary>
         string companyName { get; set; }
        /// <summary>
        /// Id of the Order
        /// </summary>
         int orderId { get; set; }
        /// <summary>
        /// Description for the Order
        /// </summary>
         string orderDescription { get; set; }
        /// <summary>
        /// Quantity of the specified Product within this Order
        /// </summary>
         int orderproductQuantity { get; set; }
        /// <summary>
        /// Unit Price of the specified Product within this Order
        /// </summary>
         decimal orderproductPrice { get; set; }
        /// <summary>
        /// Total Price of the specified Product within this Order
        /// </summary>
         decimal orderproductTotalPrice { get; set; }
        /// <summary>
        /// Id of the specified Product within this Order
        /// </summary>
         int productId { get; set; }
        /// <summary>
        /// Name of the specified Product within this Order
        /// </summary>
         string productName { get; set; }
    }
}
