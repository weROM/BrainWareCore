namespace BrainWareCore.Models
{
    /// <summary>
    /// Model representing a Product
    /// </summary>
    public class Product : IProduct
    {
        /// <summary>
        /// Id of the Product
        /// </summary>
        public int productId { get; set; }
        /// <summary>
        /// Name of the the Product
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Current price of the Product
        /// </summary>
        public decimal price { get; set; }
    }
}
