using System.Collections.Generic;
using System.Windows.Controls;
using WpfBankClient.service.Responses;

namespace WpfBankClient.Pages
{
    public partial class HistoryPage : Page
    {
        public HistoryPage(string accountNumber, IEnumerable<HistoryRecord> historyRecords)
        {
            InitializeComponent();
            AccountLabel.Content = $"History of {accountNumber}";
            HistoryDataGrid.ItemsSource = historyRecords;
        }
    }
}
