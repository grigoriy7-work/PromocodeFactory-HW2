using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using System;
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

        public Task<IQueryable<T>> GetAllAsync()
        {
            var models =  _db.Set<T>().Select(x => x);
            return Task.FromResult(models);
        }

        public async Task<T> CreateAsync(T entity)
        {
            var model = await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return model.Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await GetByIdAsync(id);
            _db.Set<T>().Remove(model);
            await _db.SaveChangesAsync();   
        }
    }
}
