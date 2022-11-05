using Domain.Transaction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.TransactionTypes.Contracts
{
    public interface ITransactionRepository
    {
        HttpStatusCode RegisterTransaction(Decimal amount, string TargetAccountId, string SederAccountId, string Title, string Nick);
        Task<Transaction> GetLastTransaction(string AccountId);

    }
}
