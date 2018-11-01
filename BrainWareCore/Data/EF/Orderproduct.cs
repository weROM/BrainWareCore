#pragma warning disable 1591
namespace BrainWareCore.Data
{
    public partial class Orderproduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
#pragma warning restore 1591
