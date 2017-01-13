using System;
using System.ServiceModel;
using WpfBankClient.BankingService;
using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    public class BankServiceAdapter : IServiceAdapter
    {
        private string accessToken;

        public BankServiceAdapter()
        {
          
        }

        public ResponseInfo LogIn(string login, string password)
        {
            var client = new BankingServiceClient();
            try
            {
                var response = client.SignIn(login, password);
                client.Close();
                accessToken = response.AccessToken;
                return new ResponseInfo(true, "Logged in successfully!");
            }
            catch (FaultException exception)
            {
                client.Close();
                return new ResponseInfo(false, exception.Message);
            }
        }
    }
}
