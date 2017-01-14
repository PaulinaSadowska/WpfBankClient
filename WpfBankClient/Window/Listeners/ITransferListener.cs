using WpfBankClient.service.RequestData;

namespace WpfBankClient.Window.Listeners
{
    public interface ITransferListener
    {
        void Transfer(TransferInfo transferInfo);
    }
}
