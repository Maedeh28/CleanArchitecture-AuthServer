using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Auth.Application.Common.Interfaces;
using Ecommerce.Auth.Infrastructutre.Persistence;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Auth.Infrastructutre.Identity.EfRepository
{
    public class ApiResourcesRepository : IEfReporitory<ApiResource>
    {
        private readonly ApplicationDbContext _applicationDb;

        public ApiResourcesRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
        }
        
        public async Task<ApiResource> AddAsync(ApiResource entity)
        {
            await _applicationDb.Set<ApiResource>().AddAsync(entity);
            await _applicationDb.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(ApiResource entity)
        {
            _applicationDb.Set<ApiResource>().Remove(entity);
            await _applicationDb.SaveChangesAsync();
        }

        public async Task<ApiResource> GetByIdAsync(int id)
        {
            return await _applicationDb.Set<ApiResource>().FindAsync(id);
        }

        public async Task<IReadOnlyList<ApiResource>> ListAsync()
        {
            return await _applicationDb.Set<ApiResource>().ToListAsync();
        }

        public async Task UpdateAsync(ApiResource entity)
        {
            _applicationDb.Entry(entity).State = EntityState.Modified;
            await _applicationDb.SaveChangesAsync();
        }
    }
}
