using System.Linq.Expressions;

namespace Scribo.Core.Interfaces
{
    public interface IReadRepository<T>
    {
        IQueryable<T> FindAllAsync(bool trackChanges);
        IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
    }
}
