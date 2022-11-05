using Domain.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserTypes.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserData(int UserId);
        Task<int> GetUserIdByName(string Name, string Surname);
    }
}
