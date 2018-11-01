using BrainWareCore.Models;
using BrainWareCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrainWareCore.Controllers
{
    /// <summary>
    /// Controller for handling Product functionality
    /// </summary>
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productService">Service for handling Product functionality</param>
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Creates a new Product
        /// </summary>
        /// <param name="product">Details of Product to create</param>
        /// <returns>The Product created</returns>
        [ProducesResponseType(typeof(IProduct), 200)]
        [HttpPost]
        public IActionResult Post(IProduct product)
        {
            return new JsonResult(_productService.Create(product));
        }
        /// <summary>
        /// Retrieves the Product with the specified id
        /// </summary>
        /// <param name="id">Id of the Product to Retrieve</param>
        /// <returns>        
        /// If the Product is found then the Product. 
        /// If the id of the Product is not valid then (404) Not Found.
        ///</returns>
        [ProducesResponseType(typeof(IProduct), 200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public IActionResult Get(int id)
        {
            IProduct product = _productService.Read(id);
            if (product == null)
            {
                return NotFound();
            }
            return new JsonResult(product);
        }
        /// <summary>
        /// Updates the specified Product
        /// </summary>
        /// <param name="product">Product to update</param>
        /// <returns>
        /// If the Product is Updated then the id of the Product. 
        /// If the id of the Product is not valid then (404) Not Found.
        /// </returns>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [HttpPut]
        public IActionResult Put(IProduct product)
        {
            int id = _productService.Update(product);
            if (id == Constants.InvalidId)
            {
                return NotFound();
            }
            return new JsonResult(id);
        }
        /// <summary>
        /// Deletes the Product with the specified id
        /// </summary>
        /// <param name="id">Id of the Product to Delete</param>
        /// <returns>
        /// If the Product is Deleted then the id of the Product. 
        /// If the id of the Product is not valid then (404) Not Found.
        /// </returns>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int idResult = _productService.Delete(id);
            if (idResult == Constants.InvalidId)
            {
                return NotFound();
            }
            return new JsonResult(idResult);
        }
    }
}