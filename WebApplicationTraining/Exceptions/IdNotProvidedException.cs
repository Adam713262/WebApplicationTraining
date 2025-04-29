namespace WebApplicationTraining.Exceptions
{
    public class IdNotProvidedException : Exception
    {
        public string Details { get; set; }

        public IdNotProvidedException(string details)
        {
            this.Details = details;
        }



    }
}

