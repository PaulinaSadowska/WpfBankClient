using WpfBankClient.BankingService;

namespace WpfBankClient.service.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Executes command on given BankServiceClient
        /// </summary>
        /// <param name="client">service client to perform operatin at</param>
        void Execute(BankingServiceClient client);
    }
}
