using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Auth.Application.Common.Interfaces;
using Ecommerce.Auth.Infrastructutre.Persistence;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Auth.Infrastructutre.Identity.EfRepository
{
    public class IdentityResourcesRepository : IEfReporitory<IdentityResource>
    {
        private readonly ApplicationDbContext _applicationDb;

        public IdentityResourcesRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<IdentityResource> AddAsync(IdentityResource entity)
        {
            await _applicationDb.Set<IdentityResource>().AddAsync(entity);
            await _applicationDb.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(IdentityResource entity)
        {
            _applicationDb.Set<IdentityResource>().Remove(entity);
            await _applicationDb.SaveChangesAsync();
        }

        public async Task<IdentityResource> GetByIdAsync(int id)
        {
            return await _applicationDb.Set<IdentityResource>().FindAsync(id);
        }

        public async Task<IReadOnlyList<IdentityResource>> ListAsync()
        {
            return await _applicationDb.Set<IdentityResource>().ToListAsync();
        }

        public async Task UpdateAsync(IdentityResource entity)
        {
            _applicationDb.Entry(entity).State = EntityState.Modified;
            await _applicationDb.SaveChangesAsync();
        }
    }
}
