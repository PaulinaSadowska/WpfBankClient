using WpfBankClient.BankingService;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.service.Commands
{
    public class DepositCommand : ICommand
    {
        private readonly DepositData _depositData;
        public DepositCommand(PaymentInfo paymentInfo)
        {
            _depositData = new DepositData
            {
                OperationTitle = paymentInfo.OperationTitle,
                AccountNumber = paymentInfo.SenderAccountNumber,
                Amount = paymentInfo.Amount
            };
        }

        public void Execute(BankingServiceClient client)
        {
            client.Deposit(_depositData);
        }
    }
}
