using System.Threading.Tasks;

namespace WpfBankClient.EventListeners
{
    public interface IHistoryListener
    {
        /// <summary>
        /// Fetch operation history for given account number
        /// </summary>
        /// <param name="accountNumber">account number which operation history should be fetched</param>
        Task GetOperationHistoryAsync(string accountNumber);
    }
}
