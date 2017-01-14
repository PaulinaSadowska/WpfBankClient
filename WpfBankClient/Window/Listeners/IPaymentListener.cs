using WpfBankClient.service.RequestData;

namespace WpfBankClient.Window.Listeners
{
    public interface IPaymentListener
    {
        void Deposit(PaymentInfo paymentInfo);
        void Withdraw(PaymentInfo paymentInfo);
    }
}
