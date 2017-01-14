﻿using System.Windows;
using System.Windows.Controls;
using WpfBankClient.Window.Listeners;

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
            _logInListener.LogIn(LoginTextBox.Text, PasswordBox.Password);
        }
    }
}