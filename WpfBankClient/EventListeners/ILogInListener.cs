using System.Threading.Tasks;

namespace WpfBankClient.EventListeners
{
    public interface ILogInListener
    {
        /// <summary>
        /// Log in 
        /// </summary>
        /// <param name="login">user login</param>
        /// <param name="password">user password</param>
        Task LogInAsync(string login, string password);
    }
}
