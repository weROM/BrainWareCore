using BrainWareCore.Models;

namespace BrainWareCore.Services
{
    /// <summary>
    /// Handles CRUD operations for the Product entity
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Create a new Product
        /// </summary>
        /// <param name="p">Product to Create</param>
        /// <returns>Product created</returns>
        IProduct Create(IProduct p);
        /// <summary>
        /// Reads an existing Product
        /// </summary>
        /// <param name="id">Id of the Product</param>
        /// <returns>The Product read</returns>
        IProduct Read(int id);
        /// <summary>
        /// Updates an existing Product
        /// </summary>
        /// <param name="p">Product to Update</param>
        /// <returns>Id of the Product Updated</returns>
        int Update(IProduct p);
        /// <summary>
        /// Deletes an Existing Product
        /// </summary>
        /// <param name="id">Id of the Product to Delete</param>
        /// <returns>Id of the Product Deleted</returns>
        int Delete(int id);
    }
}
