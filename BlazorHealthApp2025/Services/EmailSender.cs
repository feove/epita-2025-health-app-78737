// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace BlazorHealthApp2025.Services
{
    public class EmailSender
    {
        public async Task Execute(string subject, string message, string toEmail)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("leon.corbin-chatel@epita.fr", "Iboren Health");
            //var subject = "Sending with SendGrid is Fun";
            //var to = new EmailAddress("test@example.com", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var to = new EmailAddress(toEmail, "User");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, null);
            var response = await client.SendEmailAsync(msg);
            System.Console.WriteLine($"successfully sent an email to {toEmail}");
            System.Console.WriteLine($"with {subject} subject saying");
            System.Console.WriteLine($"saying {message}");
        }
    }
}   