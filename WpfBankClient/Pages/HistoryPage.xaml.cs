using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfBankClient.service.Responses;
using WpfBankClient.Window.Listeners;

namespace WpfBankClient.Pages
{
    public partial class HistoryPage : Page
    {
        private IHistoryListener _historyListener;
        public HistoryPage(IHistoryListener historyListener, List<HistoryRecord> historyRecords)
        {
            InitializeComponent();
            _historyListener = historyListener;
        }

        private void GetHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            _historyListener.GetOperationHistory(AccountTextBox.Text);
        }
    }
}
