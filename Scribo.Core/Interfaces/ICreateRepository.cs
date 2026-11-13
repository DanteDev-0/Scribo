

namespace Scribo.Core.Interfaces
{
    public interface ICreateRepository<T>
    {
        void Create(T entity);
    }
}
