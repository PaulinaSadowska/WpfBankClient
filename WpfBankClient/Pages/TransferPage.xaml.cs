using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfBankClient.EventListeners;
using WpfBankClient.service.RequestData;

namespace WpfBankClient.Pages
{
    /// <summary>
    /// Interaction logic for TransferPage.xaml
    /// </summary>
    public partial class TransferPage : Page
    {
        private readonly ITransferListener _transferListener;
        public TransferPage(ITransferListener transferListener, IEnumerable<string> accountNumbers)
        {
            InitializeComponent();
            _transferListener = transferListener;
            SenderAccountComboBox.ItemsSource = accountNumbers;
        }

        private void PerformButton_Click(object sender, RoutedEventArgs e)
        {
            _transferListener.TransferAsync(new TransferInfo
            {
                Amount = AmountTextBox.Text, 
                SenderAccountNumber = SenderAccountComboBox.Text,
                ReceiverAccountNumber = ReceiverAccountTextBox.Text,
                OperationTitle = OperationTitleTextBox.Text
            });
        }
    }
}
