using Application.TransactionTypes.Contracts;
using Domain.Transaction.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly HackatonDbContext DbContext;

        public TransactionRepository(HackatonDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public HttpStatusCode RegisterTransaction(Decimal amount, string TargetAccountId, string SederAccountId, string Title)
        {
            if (amount <= 0 || TargetAccountId is null || TargetAccountId == "" || SederAccountId is null || SederAccountId == "" || Title is null || Title == "") return HttpStatusCode.BadRequest;

           var Transaction = new Transaction
           {
               TransactDate = DateTime.Now,
               Amount = amount,
               TargetAccountId = TargetAccountId,
               SenderAccountId = SederAccountId,
               Title = Title
           };

            try
            {
                DbContext.Transaction.Add(Transaction);
                DbContext.SaveChanges();
                return HttpStatusCode.OK;
            }catch(Exception)
            {
              return HttpStatusCode.InternalServerError;
            }
        }

        public async Task<Transaction> GetLastTransactionAmount(string AccountId)
        {
            return await DbContext.Transaction.Where(e => e.TargetAccountId == AccountId).OrderBy(e => e.TransactDate).LastAsync();
        }

        public async Task<Transaction> GetLastTransactionTitle(string AccountId)
        {
            return await DbContext.Transaction.Where(e => e.TargetAccountId == AccountId).OrderBy(e => e.TransactDate).LastAsync();
        }
    }
}
