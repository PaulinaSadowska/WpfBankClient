using System.Threading.Tasks;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.EventListeners
{
    public interface ITransferListener
    {
        /// <summary>
        /// perform transfer operation
        /// </summary>
        /// <param name="transferInfo">transfer data</param>
        Task TransferAsync(TransferInfo transferInfo);
    }
}
