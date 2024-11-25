using System;
using EgeApp.Frontend.Mvc.Models.Email;

namespace EgeApp.Frontend.Mvc.Helpers.Abstract;

public interface IEmailSenderHelper
{
    Task SendEmailAsync(SendEmailModel model);
}