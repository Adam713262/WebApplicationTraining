using WebApplicationTraining.Dtos;

namespace WebApplicationTraining.Repositories
{
    public interface ICustomerRepository
    {

    public   int GetCount();
        public List<DtoCustomer> GetAll();
        public DtoCustomer GetById(string id);
        public List <DtoCustomer> GetByCompany(string name);

        public void DeleteById(string id);
        public void Update(DtoCustomer customer);
        public void Save(DtoCustomer customer);
        DtoCustomer GetByCompany();
    }
}
