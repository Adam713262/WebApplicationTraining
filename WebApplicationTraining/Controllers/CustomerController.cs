using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraining.Dtos;
using WebApplicationTraining.Exceptions;
using WebApplicationTraining.Services;

namespace WebApplicationTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //controllers calls the service layer
        ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public List<DtoCustomer> Get()
        {
            return customerService.GetAll();
        }

        //implement the httpget for getcount
        [HttpGet("count")]
        public int GetCount()
        {
            return customerService.GetCount();
        }

        [HttpGet("{id}")]
        public ActionResult<DtoCustomer> Get(string id)
        {
            try
            {
                return Ok(customerService.GetById(id));
            }
            catch (IdNotProvidedException ex)
            {
                return NotFound(new { message = ex.Details });
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new
                    {
                        message = "An unexpected error occurred.",
                        error = ex.Message
                    });
            }
        }

        [HttpGet("cobyname/{name}")]
        public ActionResult<List<DtoCustomer>> GetByCompany
            (string name)
        {

            try
            {
                return Ok(customerService.GetByCompany(name));
            }
            catch (NameNotProvidedException ex)
            {
                return NotFound(new { message = ex.Details });

            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new
                    {
                        message = "An unexpected error occurred.",
                        error = ex.Message
                    });
          
            
            }
        }

        [HttpPost]
        public ActionResult Save([FromBody] DtoCustomer customer)
        {
            try
            {
                customerService.Save(customer);
                return CreatedAtAction(nameof(Get),
                    new { id = customer.CustomerId }, customer);
            }
            catch (IdNotProvidedException ex) 
            {
                return BadRequest(ex.Details);
            }
            catch (NameNotProvidedException ex)
            {
                return BadRequest(ex.Details);
            }
            catch (Exception ex)
            {
                return StatusCode(500,

                    new
                    {
                        message = "An unexpected error occurred.",
                        error = ex.Message
                    });
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] DtoCustomer customer)
        {
            try
            {
                customerService.Update(customer);
                return new NoContentResult(); 
            }
            catch (IdNotProvidedException ex)
            {
                return BadRequest(ex.Details);
            }
            catch (NameNotProvidedException ex)
            {
                return BadRequest(ex.Details);
            }
            catch (Exception ex)
            {
                return StatusCode(500,

                    new
                    {
                        message = "An unexpected error occurred.",
                        error = ex.Message
                    });
            }
        }
    }
}



