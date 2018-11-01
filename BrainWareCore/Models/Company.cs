namespace BrainWareCore.Models
{
    /// <summary>
    /// Model representing a Company
    /// </summary>
    public class Company : ICompany
    {
        /// <summary>
        /// Id of the Company
        /// </summary>
        public int companyId { get; set; }
        /// <summary>
        /// Name of the Company
        /// </summary>
        public string name { get; set; }
    }
}
