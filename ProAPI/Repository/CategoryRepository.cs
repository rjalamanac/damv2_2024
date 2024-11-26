using ApiPelicula.Data;
using ApiPelicula.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using System.Diagnostics;

namespace ApiPelicula.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string CategoryCacheKey = "CategoryCacheKey";
        private readonly int CacheExpirationTime = 3600;
        public CategoryRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearCategoryCache();
            }
            return result;
        }

        public void ClearCategoryCache()
        {
            _cache.Remove(CategoryCacheKey);
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            if (_cache.TryGetValue(CategoryCacheKey, out ICollection<Category> categoriesCached))
                return categoriesCached;

            var categoriesFromDb = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(CategoryCacheKey, categoriesFromDb, cacheEntryOptions);
            return categoriesFromDb;
        }

        public async Task<Category> GetAsync(int id)
        {
            if (_cache.TryGetValue(CategoryCacheKey, out ICollection<Category> categoriesCached))
            {
                var category = categoriesCached.FirstOrDefault(c => c.Id == id);
                if (category != null)
                    return category;
            }

            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            return await Save();
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            category.CreatedDate = DateTime.Now;
            _context.Update(category);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await GetAsync(id);
            if (category == null)
                return false;

            _context.Categories.Remove(category);
            return await Save();
        }
    }
}
