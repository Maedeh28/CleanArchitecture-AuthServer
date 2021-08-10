using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Auth.Application.Common.Interfaces
{
    public interface IEfReporitory<T> 
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
