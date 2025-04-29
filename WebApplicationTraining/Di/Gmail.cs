using System.Diagnostics;

namespace WebApplicationTraining.Di
{
    public class Gmail : IMail
    {

        public void Receive()
        {
            Debug.WriteLine("Gmail Receive");
        }

        public void Send()
        {
            Debug.WriteLine("Gmail Send");
        }
    }
}
