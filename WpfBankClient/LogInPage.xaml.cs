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
        private readonly MainWindow _mainWindow;
        public LogInPage(MainWindow mainWindow)
            :this(mainWindow, "")
        {
        }

        public LogInPage(MainWindow mainWindow, string login)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            LoginTextBox.Text = login;
        }

        private void LogInButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.LogIn(LoginTextBox.Text, PasswordBox.Password);
        }
    }
}
