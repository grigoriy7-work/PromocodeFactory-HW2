using PromoCodeFactory.Core.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(Guid id);
    }
}