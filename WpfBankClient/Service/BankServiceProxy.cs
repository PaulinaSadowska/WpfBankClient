using System.Collections.Generic;
using System.ServiceModel;
using WpfBankClient.BankingService;
using WpfBankClient.service.Commands;
using WpfBankClient.service.RequestData;
using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    public class BankServiceProxy : IServiceProxy
    {
        private string _accessToken;
        private List<string> _accountNumbers;

        public BankServiceProxy()
        {
            _accountNumbers = new List<string>();
        }

        public ResponseInfo LogIn(string login, string password)
        {
            var logIn = new LogInCommand(login, password);
            var response = ExecuteCommand(logIn);
            _accessToken = logIn.AccessToken;
            _accountNumbers = logIn.AccountNumbers;
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
            var transfer = new TransferCommand(transferInfo, _accessToken);
            return ExecuteCommand(transfer);
        }

        public HistoryResponseInfo OperationHistory(string accountNumber)
        {
            var history = new HistoryCommand(accountNumber, _accessToken);
            var response = ExecuteCommand(history);
            return new HistoryResponseInfo(response, history.HistoryRecords);
        }

        public List<string> GetAccountNumbers()
        {
            return _accountNumbers;
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
