using DemoBLL.Interfaces;
using DemoDAL.Contexts;
using DemoDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBLL.Repositories
{
    public class GenericRepository<T>:IGenericRepositories<T> where T : class
    {
        private MVCAppContext _dbContext;
        public GenericRepository(MVCAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Add(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            return  await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        =>
            //_dbContext.Set<T>().Where(d => d.Id == id).FirstOrDefault();
            await _dbContext.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAll()
        =>
            await _dbContext.Set<T>().ToListAsync();


        public async Task<int> Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
