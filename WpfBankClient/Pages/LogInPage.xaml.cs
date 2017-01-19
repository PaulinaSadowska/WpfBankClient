using System.Windows;
using System.Windows.Controls;
using WpfBankClient.EventListeners;

namespace WpfBankClient.Pages
{
    public partial class LogInPage : Page
    {
        private readonly ILogInListener _logInListener;

        public LogInPage(ILogInListener logInListener)
            :this(logInListener, "")
        {
        }

        public LogInPage(ILogInListener logInListener, string login)
        {
            InitializeComponent();
            _logInListener = logInListener;
            LoginTextBox.Text = login;
        }

        private void LogInButton_OnClick(object sender, RoutedEventArgs e)
        {
            _logInListener.LogInAsync(LoginTextBox.Text, PasswordBox.Password);
        }
    }
}
