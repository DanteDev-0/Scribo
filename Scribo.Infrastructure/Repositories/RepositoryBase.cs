using Microsoft.EntityFrameworkCore;
using Scribo.Core.Interfaces;
using System.Linq.Expressions;

namespace Scribo.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T>(RepositoryContext context) : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _context = context;

        public IQueryable<T> FindAllAsync(bool trackChanges) =>
            !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

        public IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);

        public void Create(T entity) => _context.Set<T>().Add(entity);
    }

}
