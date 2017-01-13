using WpfBankClient.service.RequestData;
using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    public class MockServiceAdapter : IServiceAdapter
    {
        public ResponseInfo LogIn(string login, string password)
        {
            return new ResponseInfo(true, $"You logged in successfully as {login}");
        }

        public ResponseInfo Deposit(PaymentInfo paymentInfo)
        {
            throw new System.NotImplementedException();
        }

        public ResponseInfo Withdraw(PaymentInfo paymentInfo)
        {
            throw new System.NotImplementedException();
        }

        public ResponseInfo Transfer(TransferInfo transferInfo)
        {
            throw new System.NotImplementedException();
        }

        public ResponseInfo OperationHistory(string accountNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
