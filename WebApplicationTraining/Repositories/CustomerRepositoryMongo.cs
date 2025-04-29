using WebApplicationTraining.Dtos;

namespace WebApplicationTraining.Repositories
{
    public class CustomerRepositoryMongo : ICustomerRepository
    {
        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public List<DtoCustomer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<DtoCustomer> GetByCompany(string name)
        {
            throw new NotImplementedException();
        }

        public DtoCustomer GetByCompany()
        {
            throw new NotImplementedException();
        }

        public DtoCustomer GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            return 999;
        }

        public void Save(DtoCustomer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(DtoCustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}
