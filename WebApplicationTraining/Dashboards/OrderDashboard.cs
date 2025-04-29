using Microsoft.EntityFrameworkCore;
using WebApplicationTraining.Dtos;
using WebApplicationTraining.Models;

namespace WebApplicationTraining.Dashboards
{
    public class OrderDashboard
    {
        //link into EF
        NorthwindContext context;
        public OrderDashboard()
        {
            context = new NorthwindContext();
        }

        public int GetCount()
        {
            var q = context.Orders.Count();
            return q;
        }

        public List<DtoShipCountryTotal> GetShipCountryTotals(int yr)
        {
            var q = (from row in context.Orders
                     where row.OrderDate.Value.Year == yr
                     group row by row.ShipCountry into CountryGroup
                     select new DtoShipCountryTotal
                     {
                         Country = CountryGroup.Key,
                         Total = CountryGroup.Sum(o => o.Freight)

                     }
                     ).ToList();

            return q;
        }
        //url
        public List<DtoCustomerOrders> GetCustomerOrders()
        {
            var q = (from order in context.Orders
                     join customer in context.Customers
                     on order.CustomerId equals customer.CustomerId
                     select new DtoCustomerOrders
                     {
                         CustomerID = customer.CustomerId,
                         OrderID = order.OrderId,
                         CustomerName = customer.CompanyName,
                         Freight = order.Freight
                     }).AsNoTracking().ToList();

            return q;
        }
    }
}