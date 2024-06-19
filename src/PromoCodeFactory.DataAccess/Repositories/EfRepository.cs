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

        public EfRepository(DataBaseContext db, IEnumerable<T> data) 
        {
            _db = db;
            _db.Set<T>().AddRange(data);
            _db.SaveChanges();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_db.Set<T>().AsEnumerable());
        }

        public async Task CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();   
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            var model = await GetByIdAsync(id);
            model = _db.Entry(entity).Entity;
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
