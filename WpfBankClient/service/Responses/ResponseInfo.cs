namespace WpfBankClient.service.Responses
{
    public class ResponseInfo
    {
        public bool Succeeded { get; set;  }
        public string Message { get; set;  }

        public ResponseInfo(bool succedded, string message)
        {
            Succeeded = succedded;
            Message = message;
        }
    }
}
