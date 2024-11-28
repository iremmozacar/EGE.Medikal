using EgeApp.Frontend.Mvc.Helpers.Abstract;
using EgeApp.Frontend.Mvc.Models.Email;

public class EmailSenderSmtp : IEmailSenderHelper
{
    private readonly string _host;
    private readonly int _port;
    private readonly bool _enableSsl;
    private readonly string _userName;
    private readonly string _password;

    public EmailSenderSmtp(IConfiguration configuration)
    {
        _host = configuration["EmailSender:Host"];
        _port = configuration.GetValue<int>("EmailSender:Port");
        _enableSsl = configuration.GetValue<bool>("EmailSender:EnableSSL");
        _userName = configuration["EmailSender:UserName"];
        _password = configuration["EmailSender:Password"];
    }

    public Task SendEmailAsync(SendEmailModel model)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailAsync(string emailTo, string subject, string body)
    {
        throw new NotImplementedException();
    }

    // Geri kalan kodlar...
}
