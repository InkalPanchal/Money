using BankingApp.Models;
using BankingApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface IUserAccountService : IRepository<UserAccount>
    {
        public Task<UserAccount> getUserByAccountNumber(string actNo);
    }
    public class UserAccountService : Repository<UserAccount>, IUserAccountService
    {
        public UserAccountService(BankingAppContext bankingAppContext) : base(bankingAppContext)
        {

        }

        public async Task<UserAccount> getUserByAccountNumber(string actNo)
        {
            try
            {
                var user =  await _dbContext.UserAccounts.Where(a => a.AccountNumber == actNo).FirstOrDefaultAsync();
                return user != null ? user : null;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
