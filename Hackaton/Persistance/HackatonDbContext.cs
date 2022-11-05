using Domain.Account.Entities;
using Domain.Transaction.Entities;
using Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance
{
    public class HackatonDbContext : DbContext
    {
        public HackatonDbContext(DbContextOptions<HackatonDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.ApplyConfigurationsFromAssembly(typeof(HackatonDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
