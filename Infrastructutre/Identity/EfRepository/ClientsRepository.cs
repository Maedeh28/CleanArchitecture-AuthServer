using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Auth.Application.Common.Interfaces;
using Ecommerce.Auth.Infrastructutre.Persistence;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Auth.Infrastructutre.Identity.EfRepository
{
    public class ClientsRepository : IEfReporitory<Client>
    {
        private readonly ApplicationDbContext _applicationDb;

        public ClientsRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<Client> AddAsync(Client entity)
        {
            await _applicationDb.Set<Client>().AddAsync(entity);
            await _applicationDb.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Client entity)
        {
            _applicationDb.Set<Client>().Remove(entity);
            await _applicationDb.SaveChangesAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _applicationDb.Set<Client>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Client>> ListAsync()
        {
            return await _applicationDb.Set<Client>().ToListAsync();
        }

        public async Task UpdateAsync(Client entity)
        {
            _applicationDb.Entry(entity).State = EntityState.Modified;
            await _applicationDb.SaveChangesAsync();
        }
    }
}
