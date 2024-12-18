using ApiPelicula.Data;
using ApiPelicula.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using System.Diagnostics;

namespace ApiPelicula.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string LibroEntityCacheKey = "LibroEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public LibroRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(LibroEntityCacheKey);
        }

        public async Task<ICollection<LibroEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(LibroEntityCacheKey, out ICollection<LibroEntity> LibrosCached))
                return LibrosCached;

            var librosFromDb = await _context.Libros.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(LibroEntityCacheKey, librosFromDb, cacheEntryOptions);
            return librosFromDb;
        }

        public async Task<LibroEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(LibroEntityCacheKey, out ICollection<LibroEntity> LibrosCached))
            {
                var LibroEntity = LibrosCached.FirstOrDefault(c => c.Id == id);
                if (LibroEntity != null)
                    return LibroEntity;
            }

            return await _context.Libros.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Libros.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(LibroEntity LibroEntity)
        {
            _context.Libros.Add(LibroEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(LibroEntity LibroEntity)
        {
            LibroEntity.CreatedDate = DateTime.Now;
            _context.Update(LibroEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var LibroEntity = await GetAsync(id);
            if (LibroEntity == null)
                return false;

            _context.Libros.Remove(LibroEntity);
            return await Save();
        }
    }
}
