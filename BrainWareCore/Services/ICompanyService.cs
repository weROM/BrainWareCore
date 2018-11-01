using BrainWareCore.Models;

namespace BrainWareCore.Services
{
    /// <summary>
    /// Handles CRUD operations for the Company entity
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Create a new Company
        /// </summary>
        /// <param name="c">Company to Create</param>
        /// <returns>Company created</returns>
        ICompany Create(ICompany c);
        /// <summary>
        /// Reads an existing Company
        /// </summary>
        /// <param name="id">Id of the Company</param>
        /// <returns>The Company read</returns>
        ICompany Read(int id);
        /// <summary>
        /// Updates an existing Company
        /// </summary>
        /// <param name="c">Company to Update</param>
        /// <returns>Id of the Company Updated</returns>
        int Update(ICompany c);
        /// <summary>
        /// Deletes an Existing Company
        /// </summary>
        /// <param name="id">Id of the Company to Delete</param>
        /// <returns>Id of the Company Deleted</returns>
        int Delete(int id);
    }
}
