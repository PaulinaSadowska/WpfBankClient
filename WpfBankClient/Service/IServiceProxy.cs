﻿using System.Collections.Generic;
using WpfBankClient.service.RequestData;
using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    public interface IServiceProxy
    {
        ResponseInfo LogIn(string login, string password);
        ResponseInfo Deposit(PaymentInfo paymentInfo);
        ResponseInfo Withdraw(PaymentInfo paymentInfo);
        ResponseInfo Transfer(TransferInfo transferInfo);
        HistoryResponseInfo OperationHistory(string accountNumber);
        List<string> GetAccountNumbers();
        void LogOut();
    }
}