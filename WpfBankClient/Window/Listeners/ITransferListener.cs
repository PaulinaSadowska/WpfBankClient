using System.Threading.Tasks;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.Window.Listeners
{
    public interface ITransferListener
    {
        Task TransferAsync(TransferInfo transferInfo);
    }
}
