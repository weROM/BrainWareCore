namespace BrainWareCore.Models
{
    /// <summary>
    /// Interface for the Company model
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// Id of the Company
        /// </summary>
        int companyId { get; set; }
        /// <summary>
        /// Name of the Company
        /// </summary>
        string name { get; set; }
    }
}
