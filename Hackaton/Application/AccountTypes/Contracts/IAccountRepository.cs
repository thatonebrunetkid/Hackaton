using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.AccountTypes.Contracts
{
    public interface IAccountRepository
    {
        HttpStatusCode MakeTransfer(string SourceAccount, string DestinationAccount, Decimal amount);
        Task<string> GetAccountById(int UserId);
        Task<int> GetIdByAccount(string AccountNo);
    }
}
