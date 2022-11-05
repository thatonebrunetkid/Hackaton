using Application.AccountTypes.Contracts;
using Application.TransactionTypes.Contracts;
using Application.UserTypes.Contracts;
using Domain.Common.TransactionExecute.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DonateTypes.Handlers
{
    public class DonateHandlerRequest : IRequest<HttpStatusCode>
    {
        public TransactionExecuteDTO TransactionExecuteDTO { get; set; }
    }

    public class DonateHandlerHandler : IRequestHandler<DonateHandlerRequest, HttpStatusCode>
    {
        private readonly IUserRepository UserRepository;
        private readonly IAccountRepository AccountRepository;
        private readonly ITransactionRepository TransactionRepository;

        public DonateHandlerHandler(IUserRepository UserRepository, IAccountRepository AccountRepository, ITransactionRepository TransactionRepository)
        {
            this.UserRepository = UserRepository;
            this.AccountRepository = AccountRepository;
            this.TransactionRepository = TransactionRepository;
        }

        public async Task<HttpStatusCode> Handle(DonateHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await UserRepository.GetUserIdByName(request.TransactionExecuteDTO.Name, request.TransactionExecuteDTO.Surname);
            var TargetAccountNumber = await AccountRepository.GetAccountById(userId);

            var TransferResult = AccountRepository.MakeTransfer(request.TransactionExecuteDTO.SenderAccountId, TargetAccountNumber, request.TransactionExecuteDTO.Amount);
            if (TransferResult != HttpStatusCode.OK) return TransferResult;

            var TransactionResult = TransactionRepository.RegisterTransaction(request.TransactionExecuteDTO.Amount, TargetAccountNumber, request.TransactionExecuteDTO.SenderAccountId, request.TransactionExecuteDTO.DonateMessage, request.TransactionExecuteDTO.Nick);
            if (TransactionResult != HttpStatusCode.OK) return TransactionResult;
            return HttpStatusCode.OK;
        }
    }
}
