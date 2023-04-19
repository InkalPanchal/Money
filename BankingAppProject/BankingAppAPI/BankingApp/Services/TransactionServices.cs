using BankingApp.Models;
using BankingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface ITransactionServices : IRepository<Transaction>
    {

    }
    public class TransactionServices : Repository<Transaction>, ITransactionServices
    {
        public IUserAccountService _userAccountService { get; set; }

        public TransactionServices(BankingAppContext bankingAppContext, IUserAccountService userAccountService) : base(bankingAppContext)
        {
            _userAccountService = userAccountService;
        }

        public new async Task<Transaction> Add(Transaction transaction)
        {
            UserAccount userAccount = await _userAccountService.getUserByAccountNumber(transaction.AccountNumber);

            if (transaction.TransactionType == 1)
            {
                userAccount.Amount = userAccount.Amount + transaction.TransactionAmmount;
            }
            else if (transaction.TransactionType == 2)
            {
                userAccount.Amount = userAccount.Amount - transaction.TransactionAmmount;
            }
            await _dbContext.SaveChangesAsync();
            return await base.Add(transaction);
        }
    }
}
