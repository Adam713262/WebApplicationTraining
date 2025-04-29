using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationTraining.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace WebApplicationTraining.Dashboards.Tests
{
    [TestClass()]
    public class CustomerDashboardTests

    {

        CustomerDashboard customerDashboard;
        [TestInitialize()]


        public void Setup()
        {
            customerDashboard = new CustomerDashboard();
        }

        [TestMethod()]
        public void GetFrenchCustomersTest()
        {
            var actual = customerDashboard.GetFrenchCustomers();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        [TestMethod()]
        public void GetSpanishCustomersTest()
        {
            var actual = customerDashboard.GetSpanishCustomers();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Any());
        }

        [TestMethod()]
        public void GetContactsTest()
        {
            var actual = customerDashboard.GetContacts();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() > 0);
            foreach (var contact in actual)
            {
                Console.WriteLine(contact.ContactName);
            }
        }

        [TestMethod()]
        public void GetCityTotalsTest()
        {
            var actual = customerDashboard.GetCityTotals();
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count() ==5);

            foreach (var row in actual)
            {
                Console.WriteLine(row.City);
                Console.WriteLine(row.Total);
            }
        }
    }
}