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
        private IServiceAdapter bankingService;

        public MainWindow()
        {
            InitializeComponent();
            bankingService = new MockServiceAdapter();
            NavigateTo(new LogInPage(bankingService));
        }

        private void MenuItemLogIn_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new LogInPage(bankingService));
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
    }
}
