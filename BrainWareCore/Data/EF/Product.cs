#pragma warning disable 1591
using System.Collections.Generic;

namespace BrainWareCore.Data
{
    public partial class Product
    {
        public Product()
        {
            Orderproduct = new HashSet<Orderproduct>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public ICollection<Orderproduct> Orderproduct { get; set; }
    }
}
#pragma warning restore 1591
