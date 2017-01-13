using System.Windows;
using System.Windows.Controls;
using WpfBankClient.service;

namespace WpfBankClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceAdapter _bankingService;

        public MainWindow()
        {
            InitializeComponent();
            _bankingService = new BankServiceAdapter();
            NavigateTo(new LogInPage(this));
        }

        private void MenuItemLogIn_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new LogInPage(this));
        }

        private void MenuItemDeposit_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new DepositWithdrawPage(OperationType.Deposit));
        }


        private void NavigateTo(Page page)
        {
            MainFrame.NavigationService.Navigate(page);
        }

        private void MenuItemWithdraw_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new DepositWithdrawPage(OperationType.Withdraw));
        }

        private void MenuItemLogOut_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO - LOG OUT
        }

        private void MenuItemHistory_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new EmptyPage());//TODO
        }

        private void MenuItemTransfer_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new EmptyPage());
        }

        public void LogIn(string login, string password)
        {
            var response = _bankingService.LogIn(login, password);
            MessageBox.Show(response.Message);
            if (response.Succeeded)
            {
                //hide login button
                //show log out button
                NavigateTo(new EmptyPage()); //navigate somewhere
            }
            else
            {
                NavigateTo(new LogInPage(this, login));
            }
        }
    }
}
