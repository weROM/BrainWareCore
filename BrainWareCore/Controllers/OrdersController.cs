using System.Collections.Generic;
using BrainWareCore.Models;
using BrainWareCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrainWareCore.Controllers
{
    /// <summary>
    /// Controller for handling Orders functionality
    /// </summary>
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ordersService">Service for handling Orders functionality</param>
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        /// <summary>
        /// Returns a list of Orders for the Company id passed
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>List of Orders for the specified Company</returns>
        [HttpGet("{id}")]
        public List<Order> ForCompany(int id)
        {
            return _ordersService.GetOrdersByCompany(id);
        }
        /// <summary>
        /// Returns a list of Order Details for the Company id passed
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>List of Orders Details for the specified Company. This is a flattened list of Orders.</returns>
        [HttpGet("{id}/Details")]
        public List<OrderDetails> DetailsForCompany(int id)
        {
            return _ordersService.GetOrderDetailsByCompany(id);
        }
    }
}