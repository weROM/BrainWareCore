using BrainWareCore.Models;
using BrainWareCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static BrainWareCoreTest.BrainWareContextTestDB;
using static BrainWareCoreTest.BrainWareServicesTest;

namespace BrainWareCoreTest
{
    [TestClass]
    public class OrderServiceTests
    {
        private const string newTestOrderDescription = "New Test Order Description";
        private const decimal newTestOrderPrice = 10.3M;
        private const int testCompanyId = 1;
        private const string testCompanyName = "Test Company Name";
        private const string newTestProductName = "Test Product Name";
        private const decimal newTestProductPrice = 30.3M;
        private const int newTestProductQuantity = 7;

        // Creates a basic test Order with no associations
        private IOrder CreateTestOrder(IOrderService os)
        {
            return os.Create(new Order() {
                company = new Company()
                {
                    companyId = testCompanyId,
                    name = testCompanyName
                },
                description = newTestOrderDescription
            });
        }

        // Creates a basic test Product
        private IProduct CreateTestProduct(IProductService ps)
        {
            return ps.Create(new Product() { name = newTestProductName, price = newTestProductPrice });
        }

        [TestMethod]
        public void CanCreateTestOrder()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IOrderService os = GetOrderService(bwc);
                IOrder o = CreateTestOrder(os);

                Assert.IsNotNull(o);
                Assert.IsTrue(o.description == newTestOrderDescription);
            }
        }

        [TestMethod]
        public void CanReadTestOrder()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IOrderService os = GetOrderService(bwc);
                IOrder oTest = CreateTestOrder(os);
                IOrder o = os.Read(oTest.orderId);

                Assert.IsNotNull(o);
            }
        }

        [TestMethod]
        public void CanUpdateTestOrder()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IOrderService os = GetOrderService(bwc);
                IOrder o = CreateTestOrder(os);
                o.description = newTestOrderDescription;
                int id = os.Update(o);
                o = os.Read(o.orderId);

                Assert.AreEqual(o.description, newTestOrderDescription);
                Assert.AreEqual(o.company.companyId, testCompanyId);
            }
        }

        [TestMethod]
        public void CanDeleteTestOrder()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IOrderService os = GetOrderService(bwc);
                IOrder o = CreateTestOrder(os);
                int id = os.Delete(o.orderId);
                o = os.Read(o.orderId);

                Assert.IsNull(o);
            }
        }

        [TestMethod]
        public void CanCreateTestOrderWithProduct()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IOrderService os = GetOrderService(bwc);
                IProductService ps = GetProductService(bwc);
                IOrder o = CreateTestOrder(os);
                IProduct p = CreateTestProduct(ps);

                o.orderProducts = new List<OrderProduct>();
                o.orderProducts.Add(new OrderProduct()
                { orderId = o.orderId,
                    productId = p.productId,
                    price = newTestProductPrice,
                    quantity = newTestProductQuantity
                });
                os.Update(o);
                o = os.Read(o.orderId);

                Assert.IsTrue(o.orderProducts.Count == 1);
                Assert.AreEqual(o.orderProducts[0].price, newTestProductPrice);
                Assert.AreEqual(o.orderProducts[0].quantity, newTestProductQuantity);
            }
        }
    }
}
