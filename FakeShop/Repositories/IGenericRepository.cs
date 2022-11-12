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

        Task Insert(T entity);

        Task Delete(int id);

        Task Delete(IList<T> entities);

        void Update(T entity);
    }
}
