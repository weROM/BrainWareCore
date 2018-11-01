using BrainWareCore.Services;

namespace BrainWareCoreTest
{
    static class BrainWareServicesTest
    {
        public static ICompanyService GetCompanyService(BrainWareCore.Data.BrainWareContext bwc)
        {
            return new CompanyService(bwc);
        }
        public static IOrderService GetOrderService(BrainWareCore.Data.BrainWareContext bwc)
        {
            return new OrderService(bwc);
        }
        public static IProductService GetProductService(BrainWareCore.Data.BrainWareContext bwc)
        {
            return new ProductService(bwc);
        }
        public static IOrdersService GetOrdersService(BrainWareCore.Data.BrainWareContext bwc)
        {
            return new OrdersService(bwc);
        }
    }
}
