using Application.UserTypes.Contracts;
using AutoMapper;
using Domain.User.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserTypes.Handlers.Queries
{
    public class GetUserDataQuerieRequest : IRequest<GetUserDataDTO>
    {
        public int UserId { get; set; }
    }

    public class GetUserDataQuerieHandler : IRequestHandler<GetUserDataQuerieRequest, GetUserDataDTO>
    {
        private readonly IUserRepository Repository;
        private readonly IMapper Mapper;

        public GetUserDataQuerieHandler(IUserRepository Repository, IMapper Mapper)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
        }

        public async Task<GetUserDataDTO> Handle(GetUserDataQuerieRequest request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetUserData(request.UserId);
            return Mapper.Map<GetUserDataDTO>(result);
        }
    }
}
