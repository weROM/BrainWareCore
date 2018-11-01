#pragma warning disable 1591
using System.Collections.Generic;

namespace BrainWareCore.Data
{
    public partial class Order
    {
        public Order()
        {
            Orderproduct = new HashSet<Orderproduct>();
        }

        public int OrderId { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public ICollection<Orderproduct> Orderproduct { get; set; }
    }
}
#pragma warning restore 1591
