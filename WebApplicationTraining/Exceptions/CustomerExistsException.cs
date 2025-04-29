namespace WebApplicationTraining.Exceptions
{
    public class CustomerExistsException : Exception
    {
        public string Details { get; set; }
        public CustomerExistsException(string Details) {
            this.Details = Details;
        }

    }
}
