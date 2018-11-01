using BrainWareCore.Models;
using BrainWareCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BrainWareCoreTest.BrainWareContextTestDB;
using static BrainWareCoreTest.BrainWareServicesTest;

namespace BrainWareCoreTest
{
    [TestClass]
    public class CompanyServiceTests
    {

        private const string createdTestCompanyName = "Created Test Company";
        private const string newTestCompanyName = "New Test Company Name";

        // Creates a basic test Company with no associations
        private ICompany CreateTestCompany(BrainWareCore.Data.BrainWareContext bwc)
        {
            ICompanyService cs = GetCompanyService(bwc);
            return cs.Create(new Company() { name = createdTestCompanyName });
        }

        [TestMethod]
        public void CanCreateTestCompany()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                ICompany c = CreateTestCompany(bwc);

                Assert.IsNotNull(c);
                Assert.IsTrue(c.name == createdTestCompanyName);
            }
        }

        [TestMethod]
        public void CanReadTestCompany()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                ICompanyService cs = GetCompanyService(bwc);
                ICompany cTest = CreateTestCompany(bwc);
                ICompany c = cs.Read(cTest.companyId);

                Assert.IsNotNull(c);
                Assert.AreEqual(c.name, createdTestCompanyName);
            }
        }

        [TestMethod]
        public void CanUpdateTestCompany()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                ICompanyService cs = GetCompanyService(bwc);
                ICompany c = CreateTestCompany(bwc);
                c.name = newTestCompanyName;
                int id = cs.Update(c);
                c = cs.Read(c.companyId);

                Assert.IsTrue(c.name == newTestCompanyName);
            }
        }

        [TestMethod]
        public void CanDeleteTestCompany()
        {
            using (BrainWareCore.Data.BrainWareContext bwc = GetContext())
            {
                ICompanyService cs = GetCompanyService(bwc);
                ICompany c = CreateTestCompany(bwc);
                int id = cs.Delete(c.companyId);
                c = cs.Read(c.companyId);

                Assert.IsNull(c);
            }
        }
    }
}
