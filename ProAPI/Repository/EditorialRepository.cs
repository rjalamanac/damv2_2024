using ApiPelicula.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string EditorialEntityCacheKey = "EditorialEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public EditorialRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Save()
        {
            var result = await _context.SaveChangesAsync() >= 0;
            if (result)
            {
                ClearCache();
            }
            return result;
        }

        public void ClearCache()
        {
            _cache.Remove(EditorialEntityCacheKey);
        }

        public async Task<ICollection<EditorialEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(EditorialEntityCacheKey, out ICollection<EditorialEntity> EditorialsCached))
                return EditorialsCached;

            var EditorialsFromDb = await _context.Editoriales.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(EditorialEntityCacheKey, EditorialsFromDb, cacheEntryOptions);
            return EditorialsFromDb;
        }

        public async Task<EditorialEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(EditorialEntityCacheKey, out ICollection<EditorialEntity> EditorialsCached))
            {
                var EditorialEntity = EditorialsCached.FirstOrDefault(c => c.Id == id);
                if (EditorialEntity != null)
                    return EditorialEntity;
            }

            return await _context.Editoriales.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Editoriales.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(EditorialEntity editorialEntity)
        {
            editorialEntity.CreatedDate = DateTime.Now;
            _context.Editoriales.Add(editorialEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(EditorialEntity editorialEntity)
        {
            _context.Update(editorialEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var editorialEntity = await GetAsync(id);
            if (editorialEntity == null)
                return false;

            _context.Editoriales.Remove(editorialEntity);
            return await Save();
        }
    }
}
