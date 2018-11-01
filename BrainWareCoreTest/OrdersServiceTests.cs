using BrainWareCore.Data;
using BrainWareCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static BrainWareCoreTest.BrainWareContextTestDB;
using static BrainWareCoreTest.BrainWareServicesTest;

namespace BrainWareCoreTest
{
    [TestClass]
    public class OrdersServiceTests
    {
        private const int testCompanyId = 1;

        private int GetTestCompanyId(BrainWareContext bwc)
        {
            return bwc.Company.First().CompanyId;        
        }

        [TestMethod]
        public void CorrectNumberOfOrderDetailsAreReturned()
        {
            using (BrainWareContext bwc = GetContext())
            {
                IOrdersService os = GetOrdersService(bwc);
                InitializeMockData(bwc);

                List<BrainWareCore.Models.OrderDetails> ods = os.GetOrderDetailsByCompany(GetTestCompanyId(bwc));
                Assert.IsTrue(ods.Count == 5);
            }
        }

        [TestMethod]
        public void CorrectNumberOfOrdersAreReturned()
        {
            using (BrainWareContext bwc = GetContext())
            {
                IOrdersService os = GetOrdersService(bwc);
                InitializeMockData(bwc);

                List<BrainWareCore.Models.Order> orders = os.GetOrdersByCompany(GetTestCompanyId(bwc));
                Assert.IsTrue(orders.Count == 1);
            }
        }

        [TestMethod]
        public void CorrectNumberOfOrderProductsAreReturned()
        {
            using (BrainWareContext bwc = GetContext())
            {
                IOrdersService os = GetOrdersService(bwc);
                InitializeMockData(bwc);

                List<BrainWareCore.Models.Order> orders = os.GetOrdersByCompany(GetTestCompanyId(bwc));
                Assert.IsTrue(orders[0].orderProducts.Count == 5);
            }
        }
    }
}
