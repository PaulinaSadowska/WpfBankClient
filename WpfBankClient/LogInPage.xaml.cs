using System.Windows;
using System.Windows.Controls;
using WpfBankClient.service;

namespace WpfBankClient
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        private IServiceAdapter _bankAdapter;
        public LogInPage(IServiceAdapter bankAdapter)
        {
            InitializeComponent();
            _bankAdapter = bankAdapter;
        }

        private void LogInButton_OnClick(object sender, RoutedEventArgs e)
        {
            var response = _bankAdapter.LogIn(LoginTextBox.Text, PasswordBox.Password);
            MessageBox.Show(response.Message);
        }
    }
}
