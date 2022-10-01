using FakeShop.Data;
using FakeShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FakeShop.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly ShopDbContext _dbContext;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Product>();
        }

        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public Task Delete(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> Get(Expression<Func<Product, bool>> expression, List<string>? includes = null)
        {
            IQueryable<Product> query = _dbSet;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<Product>> GetAll(Expression<Func<Product, bool>>? expression = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null, List<string>? includes = null)
        {
            IQueryable<Product> query = _dbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(Product entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(Product entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
