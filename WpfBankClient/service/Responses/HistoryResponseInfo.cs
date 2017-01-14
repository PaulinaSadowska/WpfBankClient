using System.Collections.Generic;

namespace WpfBankClient.service.Responses
{
    public class HistoryResponseInfo : ResponseInfo
    {
        public List<HistoryRecord> OperationHistory { get; }

        public HistoryResponseInfo(bool succedded, string message, List<HistoryRecord> operationHistory)
            : base(succedded, message)
        {
            OperationHistory = operationHistory;
        }

        public HistoryResponseInfo(ResponseInfo response, List<HistoryRecord> operationHistory)
            : this(response.Succeeded, response.Message, operationHistory)
        {
        }
    }
}