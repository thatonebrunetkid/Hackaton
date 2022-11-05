using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Account.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountNo { get; set; }
        public Decimal Balance { get; set; }
        public bool DonateAccount { get; set; }
        public int UserId { get; set; }
    }
}
