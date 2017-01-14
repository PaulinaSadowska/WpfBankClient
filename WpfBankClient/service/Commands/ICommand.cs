using WpfBankClient.BankingService;

namespace WpfBankClient.service.Commands
{
    public interface ICommand
    {
        void Execute(BankingServiceClient client);
    }
}
