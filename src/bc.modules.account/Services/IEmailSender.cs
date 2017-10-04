using System.Threading.Tasks;

namespace bc.modules.account.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
