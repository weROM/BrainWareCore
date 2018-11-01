using BrainWareCore.Models;
using System.Linq;

namespace BrainWareCore.Services
{
    /// <summary>
    /// Handles operations for the Product entity
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly Data.BrainWareContext db;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">EF context for the Product entity</param>
        public ProductService(Data.BrainWareContext dbContext)
        {
            db = dbContext;
        }
        /// <summary>
        /// Creates a new Product.
        /// - Adds the Product
        /// - Reads the Product by id from EF
        /// </summary>
        /// <param name="p">Product to create</param>
        /// <returns>The Product created</returns>
        public IProduct Create(IProduct p)
        {
            Data.Product productData = new Data.Product();

            productData.Name = p.name;
            productData.Price = p.price;

            db.Add(productData);
            db.SaveChanges();

            return Read(productData.ProductId);
        }
        /// <summary>
        /// Reads the Product by id from EF
        /// </summary>
        /// <param name="id">Id of the Product</param>
        /// <returns>The Product if it exists, null if not</returns>
        public IProduct Read(int id)
        {
            Data.Product p = GetProductData(id);
            if (p != null)
            {
                return new Product()
                {
                    productId = p.ProductId,
                    name = p.Name,
                    price = p.Price ?? 0
                };
            }
            return null;
        }
        /// <summary>
        /// Updates the Product passed in
        /// </summary>
        /// <param name="p">Product to update</param>
        /// <returns>Id of the Product updated if it exists, Invalid Id if not</returns>
        public int Update(IProduct p)
        {
            Data.Product ProductData = GetProductData(p.productId);
            if (ProductData != null)
            {
                ProductData.Name = p.name;
                db.SaveChanges();

                return p.productId;
            }
            return Constants.InvalidId;
        }
        /// <summary>
        /// Deletes the Product specified by the id
        /// </summary>
        /// <param name="id">Id of the Product to delete</param>
        /// <returns>Id of the Product deleted if it exists, Invalid Id if not</returns>
        public int Delete(int id)
        {
            Data.Product ProductData = GetProductData(id);
            if (ProductData != null)
            {
                db.Remove(ProductData);
                db.SaveChanges();
                return id;
            }
            return Constants.InvalidId;
        }
        /// <summary>
        /// Gets the Product from EF for the Product id specified
        /// </summary>
        /// <param name="id">Id of the Product</param>
        /// <returns>EF Product if it exists, null if it does not</returns>
        private Data.Product GetProductData(int id)
        {
            return (from product in db.Product
                    where product.ProductId == id
                    select product).FirstOrDefault();
        }

    }
}
