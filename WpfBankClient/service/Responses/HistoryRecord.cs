using WpfBankClient.BankingService;

namespace WpfBankClient.service.Responses
{
    public class HistoryRecord
    {
        public string Source { get; }

        public string Title { get;  }

        public decimal Debet { get; }

        public decimal Credit { get; }

        public decimal BalanceAfterOperation { get; }

        public HistoryRecord(OperationRecord operationRecord)
        {
            Source = operationRecord.Source;
            Title = operationRecord.Title;
            Debet = operationRecord.Debet;
            Credit = operationRecord.Credit;
            BalanceAfterOperation = operationRecord.BalanceAfterOperation;
        }
    }
}
