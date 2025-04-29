using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationTraining.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationTraining.Dashboards.Tests
{
    [TestClass()]
    public class OrderDashboardTests

    {

        OrderDashboard orderDashboard;

        [TestInitialize()]


        public void Setup()
        {
            orderDashboard = new OrderDashboard();
        }

        [TestMethod()]
        public void GetCountTest()
        {
            var actual = orderDashboard.GetCount();
            Assert.IsNotNull(actual > 0);
            Console.WriteLine(actual);
        }

        [TestMethod()]
        public void GetShipCountryTotalsTest()
        {
            var actual = orderDashboard.GetShipCountryTotals(1998);
            Assert.IsTrue(actual.Count() > 0);
            foreach (var item in actual)
            {
                Console.WriteLine(item.Country);
                Console.WriteLine(item.Total);


            }
        }

        [TestMethod()]
        public void GetCustomerOrdersTest()
        {
            var actual = orderDashboard.GetCustomerOrders();
            Assert.IsTrue(actual.Count() > 0);
            foreach (var item in actual)

            {
                Console.WriteLine(item.OrderID);
                Console.WriteLine(item.CustomerName);
                Console.WriteLine(item.Freight);

            }
        }
    }
}