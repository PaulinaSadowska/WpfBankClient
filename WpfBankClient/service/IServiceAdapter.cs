using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    public interface IServiceAdapter
    {
        LoginInfo LogIn(string login, string password);
    }
}
