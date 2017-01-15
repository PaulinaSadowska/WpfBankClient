using System.Threading.Tasks;

namespace WpfBankClient.Window.Listeners
{
    public interface ILogInListener
    {
        Task LogInAsync(string login, string password);
    }
}
