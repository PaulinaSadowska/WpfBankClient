using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using WpfBankClient.BankingService;

namespace WpfBankClient.service.Commands
{
    public class LogInCommand : ICommand
    {
        private readonly string _login;
        private readonly string _password;
        public string AccessToken { get; private set; }

        public List<string> AccountNumbers { get; private set; }

        public LogInCommand(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public void Execute(BankingServiceClient client)
        {
            var response = client.SignIn(_login, _password);
            AccessToken = response.AccessToken;
            AccountNumbers = response.AccountNumbers.ToList();
        }
    }
}