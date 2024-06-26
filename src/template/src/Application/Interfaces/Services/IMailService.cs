using Genocs.BlazorClean.Template.Application.Requests.Mail;

namespace Genocs.BlazorClean.Template.Application.Interfaces.Services;

public interface IMailService
{
    Task SendAsync(MailRequest request);
}