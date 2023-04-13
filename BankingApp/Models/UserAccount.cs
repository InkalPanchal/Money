using System;
using System.Collections.Generic;

#nullable disable

namespace BankingApp.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            TransactionAccountNumberNavigations = new HashSet<Transaction>();
            TransactionUsers = new HashSet<Transaction>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string AccountNumber { get; set; }
        public decimal? Amount { get; set; }
        public string Email { get; set; }
        public int? Mobile { get; set; }
        public string Gender { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Transaction> TransactionAccountNumberNavigations { get; set; }
        public virtual ICollection<Transaction> TransactionUsers { get; set; }
    }
}
