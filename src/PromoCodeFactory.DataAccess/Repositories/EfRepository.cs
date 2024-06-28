using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataBaseContext _db;

        public EfRepository(DataBaseContext db) 
        {
            _db = db;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            var models =  _db.Set<T>().AsNoTracking().Where(x => !x.Deleted).AsEnumerable();
            return Task.FromResult(models);
        }

        public async Task CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();   
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await GetByIdAsync(id);
            model.Deleted = true;
            await _db.SaveChangesAsync();   
        }
    }
}
