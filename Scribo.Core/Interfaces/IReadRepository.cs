using System.Linq.Expressions;

namespace Scribo.Core.Interfaces
{
    public interface IReadRepository<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    }
}
