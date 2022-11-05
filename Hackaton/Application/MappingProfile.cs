using AutoMapper;
using Domain.Donate.TransactionExecute.DTO;
using Domain.Transaction.Entities;
using Domain.User.DTO;
using Domain.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetUserDataDTO>().ReverseMap();
            CreateMap<Transaction, GetLastTransactionAmountDTO>().ReverseMap();
            CreateMap<Transaction, GetLastTransactionTitleDTO>().ReverseMap();
        }
    }
}
