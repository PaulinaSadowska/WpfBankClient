using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfBankClient.EventListeners;

namespace WpfBankClient.Pages
{
    public partial class EmptyHistoryPage : Page
    {
        private readonly IHistoryListener _historyListener;

        public EmptyHistoryPage(IHistoryListener historyListener, IEnumerable<string> accountNumbers)
        {
            InitializeComponent();
            _historyListener = historyListener;
            AccountComboBox.ItemsSource = accountNumbers;
        }

        private void GetHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            _historyListener.GetOperationHistoryAsync(AccountComboBox.Text);
        }
    }
}
