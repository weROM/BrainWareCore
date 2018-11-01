using BrainWareCore.Models;
using BrainWareCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BrainWareCoreTest.BrainWareContextTestDB;
using static BrainWareCoreTest.BrainWareServicesTest;

namespace BrainWareCoreTest
{
    [TestClass]
    public class ProductServiceTests
    {

        private const string createdTestProductName = "Created Test Product";
        private const string newTestProductName = "New Test Product Name";
        private const decimal newTestProductPrice = 10.3M;

        // Creates a basic test Product with no associations
        private IProduct CreateTestProduct(IProductService ps)
        {
            return ps.Create(new Product() { name = createdTestProductName, price = newTestProductPrice });
        }

        [TestMethod]
        public void CanCreateTestProduct()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IProductService ps = GetProductService(bwc);
                IProduct p = CreateTestProduct(ps);

                Assert.IsNotNull(p);
                Assert.AreEqual(p.name, createdTestProductName);
            }
        }

        [TestMethod]
        public void CanReadTestProduct()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IProductService ps = GetProductService(bwc);
                IProduct pTest = CreateTestProduct(ps);
                IProduct p = ps.Read(pTest.productId);

                Assert.IsNotNull(p);
            }
        }

        [TestMethod]
        public void CanUpdateTestProduct()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IProductService ps = GetProductService(bwc);
                IProduct p = CreateTestProduct(ps);
                p.name = newTestProductName;
                int id = ps.Update(p);
                p = ps.Read(p.productId);

                Assert.AreEqual(p.name, newTestProductName);
                Assert.AreEqual(p.price, newTestProductPrice);
            }
        }

        [TestMethod]
        public void CanDeleteTestProduct()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                IProductService ps = GetProductService(bwc);
                IProduct p = CreateTestProduct(ps);
                int id = ps.Delete(p.productId);
                p = ps.Read(p.productId);

                Assert.IsNull(p);
            }
        }
    }
}
