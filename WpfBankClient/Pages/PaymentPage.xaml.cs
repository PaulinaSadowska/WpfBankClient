using System.Windows.Controls;
using WpfBankClient.service.RequestData;
using WpfBankClient.Window.Listeners;

namespace WpfBankClient.Pages
{
    /// <summary>
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        private readonly OperationType _operationType;
        private readonly IPaymentListener _paymentListener;

        public PaymentPage(IPaymentListener paymentListener, OperationType operationType)
        {
            InitializeComponent();
            _operationType = operationType;
            _paymentListener = paymentListener;
            PerformButton.Content = _operationType == OperationType.Deposit ? "Deposit" : "Withdraw";
        }

        private void PerformButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var paymentInfo = new PaymentInfo
            {
                Amount = AmountTextBox.Text,
                SenderAccountNumber = AccountTextBox.Text,
                OperationTitle = OperationTitleTextBox.Text
            };
            switch (_operationType)
            {
                case OperationType.Deposit:
                    _paymentListener.Deposit(paymentInfo);
                    break;
                case OperationType.Withdraw:
                    _paymentListener.Withdraw(paymentInfo);
                    break;
            }
        }
    }
}
