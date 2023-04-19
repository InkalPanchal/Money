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
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return _dbContext.Set<T>().Find(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                 _dbContext.SaveChangesAsync();
                return entity;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
