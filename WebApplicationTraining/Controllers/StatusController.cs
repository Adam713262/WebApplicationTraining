using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTraining.Di;
using WebApplicationTraining.Dtos;

namespace WebApplicationTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        UseEmail useEmail; 
        public StatusController(IMail mail)
        {
            useEmail = new UseEmail(mail);
        }

        [HttpGet]
        public string Get()
        {
            return "Status API is running";
        }

        [HttpGet("mail")]
        public void GetMail()
        {
            //test DI
            
            useEmail.CreateEmail();
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "ID is: " + id;
        }

        [HttpGet("address")]
        public string GetAddress()
        {
            return "Clare";
        }
        [HttpGet("getdata")]
        public string GetData(int from, int to)
        {
            return $"From :{from} To : {to} ";
        }

        [HttpPost]
        public DtoCustomer Post([FromBody] DtoCustomer data)
        {
            //call to service layer > save to db
            return data;
        }

        [HttpPut]
        public DtoCustomer Update([FromBody] DtoCustomer data)
        {
            //call to service layer > save to db
            return data;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            //call to service layer > save to db
            return true;
        }


    }
}

