using BrainWareCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace BrainWareCore.Services
{
    /// <summary>
    /// Handles operations for the Company entity
    /// </summary>
    public class CompanyService : ICompanyService
    {
        private readonly Data.BrainWareContext db;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">EF context for the Company entity</param>
        public CompanyService(Data.BrainWareContext dbContext)
        {
            db = dbContext;
        }
        /// <summary>
        /// Creates a new Company.
        /// - Adds the Company
        /// - Reads the Company by id from EF
        /// </summary>
        /// <param name="c">Company to create</param>
        /// <returns>The Company created</returns>
        public ICompany Create(ICompany c)
        {
            Data.Company companyData = new Data.Company();

            companyData.Name = c.name;

            db.Add(companyData);
            db.SaveChanges();

            return Read(companyData.CompanyId);
        }
        /// <summary>
        /// Reads the Company by id from EF
        /// </summary>
        /// <param name="id">Id of the Company</param>
        /// <returns>The Company if it exists, null if not</returns>
        public ICompany Read(int id)
        {
            Data.Company c = GetCompanyData(id);
            if (c != null)
            {
                return new Company()
                {
                    companyId = c.CompanyId,
                    name = c.Name
                };
            }
            return null;
        }
        /// <summary>
        /// Updates the Company passed in
        /// </summary>
        /// <param name="c">Company to update</param>
        /// <returns>Id of the Company updated if it exists, Invalid Id if not</returns>
        public int Update(ICompany c)
        {
            Data.Company companyData = GetCompanyData(c.companyId);
            if (companyData != null)
            {
                companyData.Name = c.name;
                db.SaveChanges();

                return c.companyId;
            }
            return Constants.InvalidId;
        }
        /// <summary>
        /// Deletes the Company specified by the id
        /// </summary>
        /// <param name="id">Id of the Company to delete</param>
        /// <returns>Id of the Company deleted if it exists, Invalid Id if not</returns>
        public int Delete (int id)
        {
            Data.Company companyData = GetCompanyData(id);
            if (companyData != null)
            {
                db.Remove(companyData);
                db.SaveChanges();
                return id;
            }
            return Constants.InvalidId;
        }
        /// <summary>
        /// Gets the Company from EF for the Company id specified
        /// </summary>
        /// <param name="id">Id of the Company</param>
        /// <returns>EF Company if it exists, null if it does not</returns>
        private Data.Company GetCompanyData(int id)
        {
            return (from company in db.Company
                    where company.CompanyId == id
                    select company).FirstOrDefault();
        }
    }
}
