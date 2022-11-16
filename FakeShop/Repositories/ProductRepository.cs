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

        public ShopDbContext DbContext { get => _dbContext; }

        public ProductRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Product>();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(IList<Product> products)
        {
            _dbSet.RemoveRange(products);
            await DbContext.SaveChangesAsync();
            return true;
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

            return await query.FirstOrDefaultAsync(expression);
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

            return await query.ToListAsync();
        }

        public async Task<bool> Create(Product entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Product entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
