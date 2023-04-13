using BankingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public BankingAppContext _dbContext { get; set; }
        public Repository(BankingAppContext bankingAppContext) : base() => _dbContext = bankingAppContext;

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T>> Add()
        {
            throw new NotImplementedException();
        }
    }
}
