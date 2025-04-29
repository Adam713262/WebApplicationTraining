using WebApplicationTraining.Dtos;

namespace WebApplicationTraining.Services
{
    public interface ICustomerService
    {
        List<DtoCustomer> GetAll();
        int GetCount();
        public DtoCustomer GetById(string id);

        public List<DtoCustomer> GetByCompany(string name);
        public void Save (DtoCustomer customer);

        public void Update(DtoCustomer customer);
    }
}