using System.Linq.Expressions;

namespace FakeShop.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            List<string>? includes = null
            );

        Task<T?> Get(
            Expression<Func<T, bool>> expression,
            List<string>? includes = null
            );

        Task<bool> Create(T entity);

        Task<bool> Delete(int id);

        Task<bool> Delete(IList<T> entities);

        Task<bool> Update(T entity);
    }
}
