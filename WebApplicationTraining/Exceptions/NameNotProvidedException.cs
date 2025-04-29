namespace WebApplicationTraining.Exceptions
{
    public class NameNotProvidedException : Exception
    {
        public string Details { get; set; }
        public NameNotProvidedException(string details)
        {
            this.Details = details;
        }

    }
}
