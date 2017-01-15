using System.Threading.Tasks;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.Window.Listeners
{
    public interface IPaymentListener
    {
        Task DepositAsync(PaymentInfo paymentInfo);
        Task WithdrawAsync(PaymentInfo paymentInfo);
    }
}
