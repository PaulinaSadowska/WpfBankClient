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
using WpfBankClient.service.RequestData;
using WpfBankClient.Window.Listeners;

namespace WpfBankClient.Pages
{
    /// <summary>
    /// Interaction logic for TransferPage.xaml
    /// </summary>
    public partial class TransferPage : Page
    {
        private readonly ITransferListener _transferListener;
        public TransferPage(ITransferListener transferListener)
        {
            InitializeComponent();
            _transferListener = transferListener;
        }

        private void PerformButton_Click(object sender, RoutedEventArgs e)
        {
            _transferListener.Transfer(new TransferInfo
            {
                Amount = AmountTextBox.Text, 
                SenderAccountNumber = SenderAccountTextBox.Text,
                ReceiverAccountNumber = ReceiverAccountTextBox.Text,
                OperationTitle = OperationTitleTextBox.Text
            });
        }
    }
}
