using System.Windows;
using System.Windows.Controls;
using WpfBankClient.service;
using WpfBankClient.Window.Listeners;
using WpfBankClient.Pages;
using System;
using WpfBankClient.service.RequestData;

namespace WpfBankClient
{
    public partial class MainWindow : System.Windows.Window, ILogInListener, IPaymentListener, ITransferListener, IHistoryListener
    {
        private readonly IServiceAdapter _bankingService;

        public MainWindow()
        {
            InitializeComponent();
            _bankingService = new BankServiceAdapter();
            NavigateTo(new LogInPage(this));
            HideLoggedInMenuItems();
        }

        private void MenuItemLogIn_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new LogInPage(this));
        }

        private void MenuItemDeposit_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new PaymentPage(this, OperationType.Deposit));
        }


        private void NavigateTo(Page page)
        {
            MainFrame.NavigationService.Navigate(page);
        }

        private void MenuItemWithdraw_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new PaymentPage(this, OperationType.Withdraw));
        }

        private void MenuItemLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            _bankingService.LogOut();
            HideLoggedInMenuItems();
            NavigateTo(new LogInPage(this)); 
        }

        private void MenuItemHistory_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new EmptyHistoryPage(this));
        }

        private void MenuItemTransfer_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new TransferPage(this));
        }

        public void LogIn(string login, string password)
        {
            var response = _bankingService.LogIn(login, password);
            MessageBox.Show(response.Message);
            if (response.Succeeded)
            {
                ShowLoggedInMenuItems();
                NavigateTo(new PaymentPage(this, OperationType.Deposit));
            }
            else
            {
                NavigateTo(new LogInPage(this, login));
            }
        }

        public void Deposit(PaymentInfo paymentInfo)
        {
            var response = _bankingService.Deposit(paymentInfo);
            MessageBox.Show(response.Message);
        }

        public void Withdraw(PaymentInfo paymentInfo)
        {
            var response = _bankingService.Withdraw(paymentInfo);
            MessageBox.Show(response.Message);
        }

        public void Transfer(TransferInfo transferInfo)
        {
            var response = _bankingService.Transfer(transferInfo);
            MessageBox.Show(response.Message);
        }

        public void GetOperationHistory(string accountNumber)
        {
            var response = _bankingService.OperationHistory(accountNumber);
            MessageBox.Show(response.Message);
            if (response.Succeeded)
            {
                NavigateTo(new HistoryPage(this, response.OperationHistory));
            }
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
