using System.Collections.Generic;
using System.Windows.Controls;
using WpfBankClient.EventListeners;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.Pages
{
    /// <summary>
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        private readonly OperationType _operationType;
        private readonly IPaymentListener _paymentListener;

        public PaymentPage(IPaymentListener paymentListener, OperationType operationType, IEnumerable<string> accountNumbers )
        {
            InitializeComponent();
            _operationType = operationType;
            _paymentListener = paymentListener;
            PerformButton.Content = _operationType == OperationType.Deposit ? "Deposit" : "Withdraw";
            AccountComboBox.ItemsSource = accountNumbers;
        }

        private void PerformButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var paymentInfo = new PaymentInfo
            {
                Amount = AmountTextBox.Text,
                SenderAccountNumber = AccountComboBox.Text,
                OperationTitle = OperationTitleTextBox.Text
            };
            switch (_operationType)
            {
                case OperationType.Deposit:
                    _paymentListener.DepositAsync(paymentInfo);
                    break;
                case OperationType.Withdraw:
                    _paymentListener.WithdrawAsync(paymentInfo);
                    break;
            }
        }
    }
}
