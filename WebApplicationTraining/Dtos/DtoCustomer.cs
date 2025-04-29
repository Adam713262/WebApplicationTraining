namespace WebApplicationTraining.Dtos
{
    public class DtoCustomer
    {
        //auto implemented properties
        //private fields with public getter and setter

        public string CustomerId { get; set; }
        public string Company { get; set; }
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Phone { get; set; }


        public DtoCustomer(string customerId, string company)
        {
            CustomerId = customerId;
            Company = company;
        }

        public DtoCustomer(string customerId, string company, string? contactName, string? contactTitle, string? address, string? city, string? region, string? phone) : this(customerId, company)
        {
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            Region = region;
            Phone = phone;
        }

        public DtoCustomer()
        {
        }
    }
}
