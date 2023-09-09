using GenocsBlazor.Application.Requests.Mail;
using System.Threading.Tasks;

namespace GenocsBlazor.Application.Interfaces.Services;

public interface IMailService
{
    Task SendAsync(MailRequest request);
}