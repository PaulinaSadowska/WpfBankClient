using System.Threading.Tasks;

namespace WpfBankClient.Window.Listeners
{
    public interface IHistoryListener
    {
        Task GetOperationHistoryAsync(string accountNumber);
    }
}
