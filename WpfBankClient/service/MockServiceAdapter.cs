using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    public class MockServiceAdapter : IServiceAdapter
    {
        public ResponseInfo LogIn(string login, string password)
        {
            return new ResponseInfo(true, $"You logged in successfully as {login}");
        }
    }
}
