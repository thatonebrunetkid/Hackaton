using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Transaction.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime TransactDate { get; set; }
        public Decimal Amount { get; set; }
        public string TargetAccountId { get; set; }
        public string SenderAccountId { get; set; }
        public string Title { get; set; }
        public string Nick { get; set; }
    }
}
