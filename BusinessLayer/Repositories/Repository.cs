using DataAccessLayer;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            
        }
        public async Task AddAsync(T obj)
        {
            await _dbSet.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
        }

        public  void DeleteAsync(T Id)
        {
            _dbSet.Remove(Id);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.OrderBy(T => T).ToListAsync();
        }

        public async Task<T> GetId(int Id)
        {
           return  await _dbSet.FindAsync(Id);
        }

        public T UpdateAsync(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return obj;
        }
    }
}
