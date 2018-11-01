#pragma warning disable 1591
using System.Collections.Generic;

namespace BrainWareCore.Data
{
    public partial class Company
    {
        public Company()
        {
            Order = new HashSet<Order>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
#pragma warning restore 1591
