using System;
using System.ServiceModel;
using WpfBankClient.BankingService;
using WpfBankClient.service.RequestData;
using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    public class BankServiceAdapter : IServiceAdapter
    {
        private string _accessToken;

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
                _accessToken = response.AccessToken;
                return new ResponseInfo(true, "Logged in successfully!");
            }
            catch (FaultException exception)
            {
                client.Close();
                return new ResponseInfo(false, exception.Message);
            }
        }

        public ResponseInfo Deposit(PaymentInfo paymentInfo)
        {
            var client = new BankingServiceClient();
            try
            {
                client.Deposit(new DepositData
                {
                    OperationTitle = paymentInfo.OperationTitle,
                    AccountNumber = paymentInfo.SenderAccountNumber,
                    Amount = paymentInfo.Amount
                });
                client.Close();
                return new ResponseInfo(true, "Deposit performed successfully!");
            }
            catch (FaultException exception)
            {
                client.Close();
                return new ResponseInfo(false, exception.Message);
            }
        }

        public ResponseInfo Withdraw(PaymentInfo paymentInfo)
        {
            var client = new BankingServiceClient();
            try
            {
                client.Withdraw(new WithdrawData
                {
                    OperationTitle = paymentInfo.OperationTitle,
                    AccountNumber = paymentInfo.SenderAccountNumber,
                    Amount = paymentInfo.Amount,
                    AccessToken = _accessToken
                });
                client.Close();
                return new ResponseInfo(true, "Withdraw performed successfully!");
            }
            catch (FaultException exception)
            {
                client.Close();
                return new ResponseInfo(false, exception.Message);
            }
        }

        public ResponseInfo Transfer(TransferInfo transferInfo)
        {
            throw new NotImplementedException();
        }

        public ResponseInfo OperationHistory(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            _accessToken = null;
        }
    }
}
