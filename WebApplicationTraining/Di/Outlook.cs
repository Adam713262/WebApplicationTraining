using System.Diagnostics;

namespace WebApplicationTraining.Di
{
    public class Outlook : IMail
    {
        public void Receive()
        {
            Debug.WriteLine("Outlook Receive");
        }

        public void Send()
        {
            Debug.WriteLine("Outlook Send");
        }
    }
}
