using Application.TransactionTypes.Contracts;
using AutoMapper;
using Domain.Donate.TransactionExecute.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.TransactionTypes.Queries
{
    public class GetLastTransactionAmountQuerieRequest : IRequest<GetLastTransactionAmountDTO>
    {
        public string AccountNumber { get; set; }
    }

    public class GetLastTransactionAmountQuerieHandler : IRequestHandler<GetLastTransactionAmountQuerieRequest, GetLastTransactionAmountDTO>
    {
        private readonly ITransactionRepository Repository;
        private readonly IMapper Mapper;

        public GetLastTransactionAmountQuerieHandler(ITransactionRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<GetLastTransactionAmountDTO> Handle(GetLastTransactionAmountQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetLastTransactionAmount(request.AccountNumber);
            return Mapper.Map<GetLastTransactionAmountDTO>(result);
        }
    }
}
