namespace WpfBankClient.service.Responses
{
    public class LoginInfo
    {
        public bool Succeeded { get; set;  }
        public string Message { get; set;  }

        public LoginInfo(bool succedded, string message)
        {
            Succeeded = succedded;
            Message = message;
        }
    }
}
