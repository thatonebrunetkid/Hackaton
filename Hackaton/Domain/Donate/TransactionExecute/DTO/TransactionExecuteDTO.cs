using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Common.TransactionExecute.DTO
{
    public class TransactionExecuteDTO
    {
        public Decimal Amount { get; set; }
        public string? Title { get; set; }

        public string? DonateMessage { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonPropertyName("UserId")]
        public string SenderAccountId { get; set; }
   
    }
}
