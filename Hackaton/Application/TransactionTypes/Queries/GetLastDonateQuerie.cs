using Application.AccountTypes.Contracts;
using Application.TransactionTypes.Contracts;
using Application.UserTypes.Contracts;
using Domain.Donate.TransactionExecute.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Application.TransactionTypes.Queries
{
    public class GetLastDonateQuerieRequest : IRequest<GetLastDonateDTO>
    {
        public string AccountId { get; set; }
    }

    public class GetLastDonateQuerieHandler : IRequestHandler<GetLastDonateQuerieRequest, GetLastDonateDTO>
    {
        private readonly ITransactionRepository TransactionRepository;
        private readonly IUserRepository UserRepository;
        private readonly IAccountRepository AccountRepository;

        public GetLastDonateQuerieHandler(ITransactionRepository TransactionRepository, IUserRepository UserRepository, IAccountRepository AccountRepository)
        {
            this.TransactionRepository = TransactionRepository;
            this.UserRepository = UserRepository;
            this.AccountRepository = AccountRepository;
        }

        public async Task<GetLastDonateDTO> Handle(GetLastDonateQuerieRequest request, CancellationToken cancellationToken)
        {
            var Transaction = await TransactionRepository.GetLastTransaction(request.AccountId);
            var UserId = await AccountRepository.GetIdByAccount(Transaction.SenderAccountId);

            var response = new GetLastDonateDTO
            {
                Amount = Transaction.Amount,
                Title = Transaction.Title,
                Nick = Transaction.Nick
            };

            return response;
        }
    }
}
