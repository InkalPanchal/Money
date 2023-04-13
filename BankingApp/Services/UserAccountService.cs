using BankingApp.Models;
using BankingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public interface IUserAccountService : IRepository<UserAccount>
    {

    }
    public class UserAccountService : Repository<UserAccount>, IUserAccountService
    {
        public UserAccountService(BankingAppContext bankingAppContext) : base(bankingAppContext)
        {

        }
    }
}
