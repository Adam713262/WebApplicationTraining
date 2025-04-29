using System.Diagnostics;

namespace WebApplicationTraining.Di
{
    public class UseEmail
    {

        IMail mail;

        public UseEmail()
        {
        }

        //DI 
        public UseEmail (IMail mail)
        {
            this.mail = mail;
        }

        

        public void CreateEmail()
        {
            Debug.WriteLine("Creating an email");
            mail.Send();
        }
    }
}
