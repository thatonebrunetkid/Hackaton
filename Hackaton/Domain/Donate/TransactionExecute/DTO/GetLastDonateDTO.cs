using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Donate.TransactionExecute.DTO
{
    public class GetLastDonateDTO
    {
        public string Title { get; set; }
        public Decimal Amount { get; set; }
        public string Nick { get; set; }
    }
}
