namespace WebApplicationTraining.Exceptions
{
    public class CustomerDoesntExistException : Exception
    {

        public string Details { get; set; }
        public CustomerDoesntExistException(string Details)
        {
            this.Details = Details;
        }
    }
}
