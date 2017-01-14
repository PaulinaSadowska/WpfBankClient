using WpfBankClient.BankingService;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.service.Commands
{
    public class TransferCommand : ICommand
    {
        private readonly SoapTransferData _transferData;

        public TransferCommand(TransferInfo transferInfo, string accessToken)
        {
            _transferData = new SoapTransferData
            {
                ReceiverAccountNumber = transferInfo.ReceiverAccountNumber,
                SenderAccountNumber = transferInfo.SenderAccountNumber,
                Amount = transferInfo.Amount,
                Title = transferInfo.OperationTitle,
                AccessToken = accessToken
            };
        }

        public void Execute(BankingServiceClient client)
        {
            client.Transfer(_transferData);
        }
    }
}
