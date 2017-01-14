using System.Collections.Generic;
using WpfBankClient.BankingService;
using WpfBankClient.service.Responses;

namespace WpfBankClient.service.Commands
{
    public class HistoryCommand : ICommand
    {
        private readonly string _accessToken;
        private readonly string _accountNumber;

        public List<HistoryRecord> HistoryRecords { get; private set; }

        public HistoryCommand(string accountNumber, string accessToken)
        {
            _accessToken = accessToken;
            _accountNumber = accountNumber;
        }

        public void Execute(BankingServiceClient client)
        {
            var response = client.GetOperationHistory(_accessToken, _accountNumber);
            HistoryRecords = new List<HistoryRecord>();
            foreach (var operationRecord in response.OperationRecords)
            {
                HistoryRecords.Add(new HistoryRecord(operationRecord));
            }
        }
    }
}
