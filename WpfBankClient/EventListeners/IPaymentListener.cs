using System.Threading.Tasks;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.EventListeners
{
    public interface IPaymentListener
    {
        /// <summary>
        /// Perform deposit operation
        /// </summary>
        /// <param name="paymentInfo">deposit data</param>
        Task DepositAsync(PaymentInfo paymentInfo);

        /// <summary>
        /// Perform withdraw operation
        /// </summary>
        /// <param name="paymentInfo">withdraw data</param>
        Task WithdrawAsync(PaymentInfo paymentInfo);
    }
}
