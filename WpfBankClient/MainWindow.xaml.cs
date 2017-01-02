using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBankClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateTo(new LogInPage());
        }

        private void MenuItemLogIn_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateTo(new LogInPage());
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
