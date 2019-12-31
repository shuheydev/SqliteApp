using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteApp.Standard
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataBaseContext _databaseContext;

        public ProductsRepository(string dbPath)
        {
            _databaseContext = new DataBaseContext(dbPath);
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                var tracking = await _databaseContext.Products.AddAsync(product);
                await _databaseContext.SaveChangesAsync();

                //var isAdded = tracking.State == EntityState.Added;

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            try
            {
                var products = await _databaseContext.Products.ToListAsync();
                return products;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                //FindAsyncは暗黙的に主キーで検索されるのか
                //見つからない場合はnullを返す
                var product = await _databaseContext.Products.FindAsync(id);
                return product;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> QueryProductsAsync(Func<Product, bool> predicate)
        {
            try
            {
                var products = _databaseContext.Products.Where(predicate);
                return products.ToList();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            try
            {
                var product = await _databaseContext.Products.FindAsync(id);
                var tracking = _databaseContext.Remove(product);
                await _databaseContext.SaveChangesAsync();

                var isDeleted = tracking.State == EntityState.Deleted;

                return isDeleted;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                var tracking = _databaseContext.Update(product);
                await _databaseContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;

                return isModified;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
