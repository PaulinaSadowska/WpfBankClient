using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    class MockServiceAdapter : IServiceAdapter
    {
        public LoginInfo LogIn(string login, string password)
        {
            return new LoginInfo(true, $"You logged in successfully as {login}");
        }
    }
}
