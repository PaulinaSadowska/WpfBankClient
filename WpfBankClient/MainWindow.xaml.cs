using System.Windows;
using System.Windows.Controls;
using WpfBankClient.service;
using WpfBankClient.Window.Listeners;
using WpfBankClient.Pages;
using System.Threading.Tasks;
using WpfBankClient.service.RequestData;

namespace WpfBankClient
{
    public partial class MainWindow : System.Windows.Window, ILogInListener, IPaymentListener, ITransferListener, IHistoryListener
    {
        private readonly IServiceProxy _bankingService;

        public MainWindow()
        {
            InitializeComponent();
            _bankingService = new BankServiceProxy();
            NavigateTo(new LogInPage(this));
            HideLoggedInMenuItems();
        }

        private void MenuItemLogIn_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new LogInPage(this));
        }

        private void MenuItemDeposit_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new PaymentPage(this, OperationType.Deposit, _bankingService.GetAccountNumbers()));
        }


        private void NavigateTo(Page page)
        {
            MainFrame.NavigationService.Navigate(page);
        }

        private void MenuItemWithdraw_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new PaymentPage(this, OperationType.Withdraw, _bankingService.GetAccountNumbers()));
        }

        private void MenuItemLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            _bankingService.LogOut();
            HideLoggedInMenuItems();
            NavigateTo(new LogInPage(this)); 
        }

        private void MenuItemHistory_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new EmptyHistoryPage(this, _bankingService.GetAccountNumbers()));
        }

        private void MenuItemTransfer_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new TransferPage(this, _bankingService.GetAccountNumbers()));
        }

        public async Task LogInAsync(string login, string password)
        {
            StartLoading();
            var response = await Task.Run(()=>_bankingService.LogIn(login, password));
            LoadingPanel.Visibility = Visibility.Hidden;
            ShowErrorMessage(response.Succeeded, response.Message);
            if (response.Succeeded)
            {
                ShowLoggedInMenuItems();
                NavigateTo(new PaymentPage(this, OperationType.Deposit, _bankingService.GetAccountNumbers()));
            }
            else
            {
                NavigateTo(new LogInPage(this, login));
            }
        }

        public async Task DepositAsync(PaymentInfo paymentInfo)
        {
            StartLoading();
            var response = await Task.Run(() => _bankingService.Deposit(paymentInfo));
            ShowResponseMessage(response.Message);
        }

        public async Task WithdrawAsync(PaymentInfo paymentInfo)
        {
            StartLoading();
            var response = await Task.Run(() => _bankingService.Withdraw(paymentInfo));
            ShowResponseMessage(response.Message);
        }

        public async Task TransferAsync(TransferInfo transferInfo)
        {
            StartLoading();
            var response = await Task.Run(() => _bankingService.Transfer(transferInfo));
            ShowResponseMessage(response.Message);
        }

        public async Task GetOperationHistoryAsync(string accountNumber)
        {
            StartLoading();
            var response = await Task.Run(() => _bankingService.OperationHistory(accountNumber));
            ShowErrorMessage(response.Succeeded, response.Message);
            if (response.Succeeded)
            {
                NavigateTo(new HistoryPage(accountNumber, response.OperationHistory));
            }
        }

        private void StartLoading()
        {
            LoadingPanel.Visibility = Visibility.Visible;
        }

        private void ShowErrorMessage(bool succeeded, string message)
        {
            LoadingPanel.Visibility = Visibility.Collapsed;
            if(!succeeded)
                MessageBox.Show(message);
        }

        private void ShowResponseMessage(string message)
        {
            LoadingPanel.Visibility = Visibility.Collapsed;
            MessageBox.Show(message);
        }

        private void ShowLoggedInMenuItems()
        {
            LogInMenuItem.Visibility = Visibility.Collapsed;
            DepositMenuItem.Visibility = Visibility.Visible;
            WithdrawMenuItem.Visibility = Visibility.Visible;
            TransferMenuItem.Visibility = Visibility.Visible;
            OperationHistoryMenuItem.Visibility = Visibility.Visible;
            LogOutMenuItem.Visibility = Visibility.Visible;
        }

        private void HideLoggedInMenuItems()
        {
            LogInMenuItem.Visibility = Visibility.Visible;
            DepositMenuItem.Visibility = Visibility.Collapsed;
            WithdrawMenuItem.Visibility = Visibility.Collapsed;
            TransferMenuItem.Visibility = Visibility.Collapsed;
            OperationHistoryMenuItem.Visibility = Visibility.Collapsed;
            LogOutMenuItem.Visibility = Visibility.Collapsed;
        }
    }
}
