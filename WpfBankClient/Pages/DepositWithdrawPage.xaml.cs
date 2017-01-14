using System.Windows.Controls;

namespace WpfBankClient.Pages
{
    /// <summary>
    /// Interaction logic for DepositWithdrawPage.xaml
    /// </summary>
    public partial class DepositWithdrawPage : Page
    {
        private OperationType _operationType;

        public DepositWithdrawPage(OperationType operationType)
        {
            InitializeComponent();
            _operationType = operationType;
            PerformButton.Content = _operationType == OperationType.Deposit ? "Deposit" : "Withdraw";
        }
    }
}
