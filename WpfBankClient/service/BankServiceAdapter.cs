using System;
using System.ServiceModel;
using WpfBankClient.BankingService;
using WpfBankClient.service.Commands;
using WpfBankClient.service.RequestData;
using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    public class BankServiceAdapter : IServiceAdapter
    {
        private string _accessToken;

        public ResponseInfo LogIn(string login, string password)
        {
            var logIn = new LogInCommand(login, password);
            var response = ExecuteCommand(logIn);
            _accessToken = logIn.AccessToken;
            return response;
        }

        public ResponseInfo Deposit(PaymentInfo paymentInfo)
        {
            var deposit = new DepositCommand(paymentInfo);
            return ExecuteCommand(deposit);
        }

        public ResponseInfo Withdraw(PaymentInfo paymentInfo)
        {
            var withdraw = new WithdrawCommand(paymentInfo, _accessToken);
            return ExecuteCommand(withdraw);
        }

        public ResponseInfo Transfer(TransferInfo transferInfo)
        {
            throw new NotImplementedException();
        }

        public ResponseInfo OperationHistory(string accountNumber)
        {
            throw new NotImplementedException();
        }

        private static ResponseInfo ExecuteCommand(ICommand command)
        {
            var client = new BankingServiceClient();
            try
            {
                command.Execute(client);
                client.Close();
                return new ResponseInfo(true, "Success!");
            }
            catch (FaultException exception)
            {
                client.Close();
                return new ResponseInfo(false, exception.Message);
            }
        }

        public void LogOut()
        {
            _accessToken = null;
        }
    }
}
