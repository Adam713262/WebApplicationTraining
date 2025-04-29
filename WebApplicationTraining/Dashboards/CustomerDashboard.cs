using WebApplicationTraining.Dtos;
using WebApplicationTraining.Repositories;

namespace WebApplicationTraining.Dashboards
{
    public class CustomerDashboard
    {
        CustomerRepositorySqlServer repositorySqlServer;
        public CustomerDashboard(IConfiguration configuration)
        {
            //required to pass the configuration settingcd to SQL Server
            repositorySqlServer =
                new CustomerRepositorySqlServer(configuration);

        }


        public List<DtoCustomer> GetFrenchCustomers()
        {

            List<DtoCustomer> customers = repositorySqlServer.GetAll();
            //linq query using keywords

            var q = (from row in customers
                     where row.City == "Lille" || row.City == "Paris"
                     select row
                     ).ToList(); // call the tolist the query runs

            return q;
        }

        //Write a method to return the USA customers
        public List<DtoCustomer> GetUSACustomers()
        {
            List<DtoCustomer> customers =
                repositorySqlServer.GetAll();
            //linq method based syntax

            var q = customers.Where(c => c.City == "Seattle")
                .Select(c => c)
                .ToList();

            return q;
        }
        //Write a method to return the ContactData from customers
        public List<DtoContact> GetContacts()
        {
            List<DtoCustomer> customers =
                    repositorySqlServer.GetAll();
            //project the select into dto
            var q = (from row in customers
                     select new DtoContact
                     {
                         ContactName = row.ContactName,
                         ContactTitle = row.ContactTitle
                     }
                     ).ToList();

            return q;
        }


        public List<DtoCityTotal> GetCityTotals()
        {
            List<DtoCustomer> customers =
                    repositorySqlServer.GetAll();
            var q = (from row in customers
                     group row by row.City into CityGroup
                     select new DtoCityTotal
                     {
                         City = CityGroup.Key,
                         Total = CityGroup.Count()
                     }
                     ).OrderByDescending(c => c.Total)
                     .Take(5).ToList();
            return q;
        }


























    }
}




