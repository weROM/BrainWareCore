using BrainWareCore.Models;
using BrainWareCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrainWareCore.Controllers
{
    /// <summary>
    /// Controller for handling Company functionality
    /// </summary>
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companyService">Service for handling Company functionality</param>
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        /// <summary>
        /// Creates a new Company
        /// </summary>
        /// <param name="company">Details of Company to create</param>
        /// <returns>The Company created</returns>
        [ProducesResponseType(typeof(ICompany), 200)]
        [HttpPost]
        public IActionResult Post(ICompany company)
        {
            return new JsonResult(_companyService.Create(company));
        }
        /// <summary>
        /// Retrieves the Company with the specified id
        /// </summary>
        /// <param name="id">Id of the Company to Retrieve</param>
        /// <returns>        
        /// If the Company is found then the Company. 
        /// If the id of the Company is not valid then (404) Not Found.
        ///</returns>
        [ProducesResponseType(typeof(ICompany), 200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public IActionResult Get(int id)
        {
            ICompany c = _companyService.Read(id);
            if (c == null)
            {
                return NotFound();
            }
            return new JsonResult(c);
        }
        /// <summary>
        /// Updates the specified Company
        /// </summary>
        /// <param name="company">Company to update</param>
        /// <returns>
        /// If the Company is Updated then the id of the Company. 
        /// If the id of the Company is not valid then (404) Not Found.
        /// </returns>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [HttpPut]
        public IActionResult Put(ICompany company)
        {
            int id = _companyService.Update(company);
            if (id == Constants.InvalidId)
            {
                return NotFound();
            }
            return new JsonResult(id);
        }
        /// <summary>
        /// Deletes the Company with the specified id
        /// </summary>
        /// <param name="id">Id of the Company to Delete</param>
        /// <returns>
        /// If the Company is Deleted then the id of the Company. 
        /// If the id of the Company is not valid then (404) Not Found.
        /// </returns>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            int idResult = _companyService.Delete(id);
            if (idResult == Constants.InvalidId)
            {
                return NotFound();
            }
            return new JsonResult(idResult);
        }
    }
}