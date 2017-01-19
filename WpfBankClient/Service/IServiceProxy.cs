using System.Collections.Generic;
using WpfBankClient.service.RequestData;
using WpfBankClient.service.Responses;

namespace WpfBankClient.service
{
    /// <summary>
    /// creates and performs operations on the service client
    /// </summary>
    public interface IServiceProxy
    {
        /// <summary>
        /// performs sign in operation
        /// </summary>
        /// <param name="login">user login</param>
        /// <param name="password">password</param>
        /// <returns>response status</returns>
        ResponseInfo LogIn(string login, string password);

        /// <summary>
        /// performs deposit operation
        /// </summary>
        /// <param name="paymentInfo">data needed to perform deposit</param>
        /// <returns>response status</returns>
        ResponseInfo Deposit(PaymentInfo paymentInfo);

        /// <summary>
        /// performs withdraw operation
        /// </summary>
        /// <param name="paymentInfo">data needed to perform withdraw</param>
        /// <returns>response status</returns>
        ResponseInfo Withdraw(PaymentInfo paymentInfo);

        /// <summary>
        /// performs transgfer operation
        /// </summary>
        /// <param name="transferInfo">data needed to perform transfer</param>
        /// <returns>response status</returns>
        ResponseInfo Transfer(TransferInfo transferInfo);

        /// <summary>
        /// performs fetch history operation operation
        /// </summary>
        /// <param name="accountNumber">account number which history schould be fetched</param>
        /// <returns>response status and operation history</returns>
        HistoryResponseInfo OperationHistory(string accountNumber);

        /// <summary>
        /// If user is logged in - returns its account numbers list
        /// </summary>
        /// <returns>user's account numbers list</returns>
        List<string> GetAccountNumbers();

        /// <summary>
        /// perform log out operation 
        /// </summary>
        void LogOut();
    }
}
