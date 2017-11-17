using System;

namespace RaNotification.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSample();

            Console.Read();
        }

        static void EmailSample()
        {
            var emailSample = new EmailSample();
            emailSample.StartServer();
            emailSample.ClientPost();
        }
    }
}
