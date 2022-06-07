using LinkTekTest.Core.Repositories.Base;
using LinkTekTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace LinkTekTest.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LinkTekTestContext _linkTekTestContext;

        public Repository(LinkTekTestContext linkTekTestContext)
        {
            _linkTekTestContext = linkTekTestContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            _linkTekTestContext.Set<T>().Add(entity);
            await _linkTekTestContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _linkTekTestContext.Set<T>().Remove(entity);
            await _linkTekTestContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _linkTekTestContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _linkTekTestContext.Set<T>().FindAsync(id);
        }

        public virtual Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
