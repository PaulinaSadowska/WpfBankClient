using WpfBankClient.BankingService;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.service.Commands
{
    public class WithdrawCommand : ICommand
    {
        private readonly WithdrawData _withdrawData;

        public WithdrawCommand(PaymentInfo paymentInfo, string accessToken)
        {
            _withdrawData = new WithdrawData
            {
                OperationTitle = paymentInfo.OperationTitle,
                AccountNumber = paymentInfo.SenderAccountNumber,
                Amount = paymentInfo.Amount,
                AccessToken = accessToken
            };
        }

        public void Execute(BankingServiceClient client)
        {
            client.Withdraw(_withdrawData);
        }
    }
}
