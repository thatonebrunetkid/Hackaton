using Application.UserTypes.Contracts;
using Domain.User.DTO;
using Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HackatonDbContext DbContext;

        public UserRepository(HackatonDbContext DbContex)
        {
            this.DbContext = DbContex;
        }

        public async Task<User> GetUserData(int UserId)
        {
            return await DbContext.User.FirstAsync(e => e.UserId == UserId);
        }

        public async Task<int> GetUserIdByName(string Name, string Surname)
        {
            var result = await DbContext.User.FirstAsync(e => e.Name == Name && e.Surname == Surname);
            return result.UserId;
        }
    }
}
