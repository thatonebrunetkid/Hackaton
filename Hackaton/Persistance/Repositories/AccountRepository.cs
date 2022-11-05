using Application.AccountTypes.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly HackatonDbContext DbContext;

        public AccountRepository(HackatonDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public HttpStatusCode MakeTransfer(string SourceAccount, string DestinationAccount, Decimal amount)
        {
            if (SourceAccount is null || DestinationAccount is null || amount <= 0) return HttpStatusCode.BadRequest;
            try
            {
                //get money from source account
                DbContext.Account.Where(e => e.AccountNo == SourceAccount).ToList().ForEach(e => e.Balance -= amount);
                //send money to target acount
                DbContext.Account.Where(e => e.AccountNo == DestinationAccount).ToList().ForEach(e => e.Balance += amount);
                DbContext.SaveChanges();
                return HttpStatusCode.OK;
            }catch(Exception) { return HttpStatusCode.InternalServerError; }
        }

        public async Task<string> GetAccountById(int UserId)
        {
            var result = await DbContext.Account.FirstAsync(e => e.UserId == UserId);
            return result.AccountNo;
        }

        public async Task<int> GetIdByAccount(string AccountNo)
        {
            var result = await DbContext.Account.FirstAsync(e => e.AccountNo == AccountNo);
            return result.UserId;
        }

        
    }
}
