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
    public class GetLastTransactionTitleQuerieRequest : IRequest<GetLastTransactionTitleDTO>
    {
        public string AccountNumber { get; set; }
    }


    public class GetLastTransactionTitleQuerieHandler : IRequestHandler<GetLastTransactionTitleQuerieRequest, GetLastTransactionTitleDTO>
    {
        private readonly ITransactionRepository Repository;
        private readonly IMapper Mapper;

        public GetLastTransactionTitleQuerieHandler(ITransactionRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<GetLastTransactionTitleDTO> Handle(GetLastTransactionTitleQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetLastTransactionTitle(request.AccountNumber);
            return Mapper.Map<GetLastTransactionTitleDTO>(result);
        }
    }
}
