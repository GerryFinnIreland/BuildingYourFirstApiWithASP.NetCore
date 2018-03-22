using System.Diagnostics;

namespace Exercise.API.Services
{//needs to be registered with the container so it can be injected using the built in dependency injection system
    public class LocalMailService : IMailService
    {
        private string _mailTo = "admin@mycompany.com";
        private string _mailFrom = "nonreply@mycompany.com";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService");
            Debug.WriteLine($"Subject {subject}");
            Debug.WriteLine($"Message {message}");
        }
    }
}
