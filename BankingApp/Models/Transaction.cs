using System;
using System.Collections.Generic;

#nullable disable

namespace BankingApp.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int? UserId { get; set; }
        public string AccountNumber { get; set; }
        public decimal? TransactionAmmount { get; set; }
        public int? TransactionType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual UserAccount AccountNumberNavigation { get; set; }
        public virtual UserAccount User { get; set; }
    }
}
