using WebApplicationTraining.Dtos;
using WebApplicationTraining.Exceptions;
using WebApplicationTraining.Repositories;
namespace WebApplicationTraining.Services
{
    public class CustomerService : ICustomerService
    {
        //business logic & validation
        //service layer calls the Repo Layer
        ICustomerRepository CustomerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            CustomerRepo = customerRepo;
            //CustomerRepo = new CustomerRepositorySqlServer();
        }
        public List<DtoCustomer> GetAll()
        {
            return CustomerRepo.GetAll();
        }

        public List<DtoCustomer> GetByCompany(string name)
        {
            if (name.Trim() == String.Empty || name == null
                 || name.Length < 1)
            {
                throw new
                    NameNotProvidedException("Name not valid");
            }
            return CustomerRepo.GetByCompany(name);

        }

        public DtoCustomer GetById(string id)
        {
            //id cannot be null and id must be 5 chars
            if (id.Trim() == String.Empty || id == null
                || id.Length != 5)
            {
                throw new
                    IdNotProvidedException
                    ("The customer ID was not provided");
            }
            //TODO mock testing
            return CustomerRepo.GetById(id);


        }

        public int GetCount()
        {
            return CustomerRepo.GetCount();

        }

        public void Save(DtoCustomer customer)
        {
            //Validate the cust id and name 
            //validate for duplicates - check if customer id exists 

            if (customer.CustomerId.Trim() == String.Empty || customer.CustomerId == null || customer.CustomerId.Length != 5 )
            {
                throw new IdNotProvidedException("ID of 5 chars not provided");
            }

            if (customer.Company.Trim() == String.Empty || customer.Company == null || customer.Company.Length < 1)
            {
                throw new NameNotProvidedException("Name not provided");
            }

            //todo check if id exists


            DtoCustomer customer1= CustomerRepo.GetById(customer.CustomerId);
            if (customer != null)
            {
                throw new CustomerExistsException(customer1.CustomerId + "exists");
            }
            //call the repo

            CustomerRepo.Save(customer);



        }

        public void Update(DtoCustomer customer)
        {
            

            if (customer.CustomerId.Trim() == String.Empty || customer.CustomerId == null || customer.CustomerId.Length != 5)
            {
                throw new IdNotProvidedException("ID of 5 chars not provided");
            }

            if (customer.Company.Trim() == String.Empty || customer.Company == null || customer.Company.Length < 1)
            {
                throw new NameNotProvidedException("Name not provided");
            }

            //todo check if id exists


            DtoCustomer customer1 = CustomerRepo.GetById(customer.CustomerId);
            if (customer == null)
            {
                throw new CustomerDoesntExistException(customer1.CustomerId + "does not exist!");
            }
            //call the repo

            CustomerRepo.Update(customer);

        }
    }
}
