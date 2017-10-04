using System.Threading.Tasks;

namespace bc.modules.account.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
