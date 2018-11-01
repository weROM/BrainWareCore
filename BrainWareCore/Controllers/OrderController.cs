using BrainWareCore.Models;
using BrainWareCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrainWareCore.Controllers
{
    /// <summary>
    /// Controller for handling Order functionality
    /// </summary>
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderService">Service for handling Order functionality</param>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        /// <summary>
        /// Creates a new Order
        /// </summary>
        /// <param name="order">Details of Order to create</param>
        /// <returns>The Order created</returns>
        [ProducesResponseType(typeof(IOrder), 200)]
        [HttpPost]
        public IActionResult Post(IOrder order)
        {
            return new JsonResult(_orderService.Create(order));
        }
        /// <summary>
        /// Retrieves the Order with the specified id
        /// </summary>
        /// <param name="id">Id of the Order to Retrieve</param>
        /// <returns>        
        /// If the Order is found then the Order. 
        /// If the id of the Order is not valid then (404) Not Found.
        ///</returns>    
        [ProducesResponseType(typeof(IOrder), 200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public IActionResult Get(int id)
        {
            IOrder order = _orderService.Read(id);
            if (order == null)
            {
                return NotFound();
            }
            return new JsonResult(order);
        }
        /// <summary>
        /// Updates the specified Order
        /// </summary>
        /// <param name="order">Order to update</param>
        /// <returns>
        /// If the Order is Updated then the id of the Order. 
        /// If the id of the Order is not valid then (404) Not Found.
        /// </returns>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [HttpPut]
        public IActionResult Put(IOrder order)
        {
            int id = _orderService.Update(order);
            if (id == Constants.InvalidId)
            {
                return NotFound();
            }
            return new JsonResult(id);
        }
        /// <summary>
        /// Deletes the Order with the specified id
        /// </summary>
        /// <param name="id">Id of the Order to Delete</param>
        /// <returns>
        /// If the Order is Deleted then the id of the Order. 
        /// If the id of the Order is not valid then (404) Not Found.
        /// </returns>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int idResult = _orderService.Delete(id);
            if (idResult == Constants.InvalidId)
            {
                return NotFound();
            }
            return new JsonResult(idResult);
        }
    }
}