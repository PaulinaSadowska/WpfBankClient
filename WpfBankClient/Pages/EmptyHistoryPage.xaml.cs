using System.Windows;
using System.Windows.Controls;
using WpfBankClient.Window.Listeners;

namespace WpfBankClient.Pages
{
    public partial class EmptyHistoryPage : Page
    {
        private readonly IHistoryListener _historyListener;

        public EmptyHistoryPage(IHistoryListener historyListener)
        {
            InitializeComponent();
            _historyListener = historyListener;
        }

        private void GetHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            _historyListener.GetOperationHistoryAsync(AccountTextBox.Text);
        }
    }
}
