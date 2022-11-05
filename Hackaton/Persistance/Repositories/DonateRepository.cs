using Application.CommonTypes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class DonateRepository : IDonateRepository
    {
        private readonly HackatonDbContext DbContext;

        public DonateRepository(HackatonDbContext DbContext)
        {
            this.DbContext = DbContext;
        }



    }
}
