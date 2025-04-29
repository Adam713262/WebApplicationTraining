using Microsoft.AspNetCore.Mvc;
using WebApplicationTraining.Dashboards;
using WebApplicationTraining.Dtos;

namespace WebApplicationTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDashboardController : ControllerBase
    {
        //controller calls the service/dashboard layer
        CustomerDashboard customerDashboard;
        //the framework injects an instance of a configuration 
        //class wotj seetings from app settings.json

        public CustomerDashboardController(IConfiguration configuration)
        {

            this.customerDashboard = new CustomerDashboard(configuration);
        }


        [HttpGet("frenchcustomers")]
        public ActionResult<List<DtoCustomer>>GetFrenchCustomers()
        {
            return Ok(customerDashboard.GetFrenchCustomers());
        }


        //getUSACustomers
        [HttpGet("usacustomers")]
        public ActionResult<List<DtoCustomer>> GetUSACustomers()
        {
            return Ok(customerDashboard.GetUSACustomers());
        }

        //getContacts
        [HttpGet("contacts")]
        public ActionResult<List<DtoCityTotal>> GetContacts()
        {
            return Ok(customerDashboard.GetContacts());
        }

        //getcitytotals 

        [HttpGet("citytotals")]
        public ActionResult<List<DtoCityTotal>> GetCityTotals()
        {
            return Ok(customerDashboard.GetCityTotals());
        }




    }
}

   


