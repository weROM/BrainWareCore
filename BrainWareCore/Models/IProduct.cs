namespace BrainWareCore.Models
{
    /// <summary>
    /// Interface for the Product model
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Id of the Product
        /// </summary>
        int productId { get; set; }
        /// <summary>
        /// Name of the the Product
        /// </summary>
        string name { get; set; }
        /// <summary>
        /// Current price of the Product
        /// </summary>
        decimal price { get; set; }
    }
}
