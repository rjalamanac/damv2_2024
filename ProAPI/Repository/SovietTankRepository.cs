using ApiPelicula.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class SovietTankRepository : ISovietTanksRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string SovietTankEntityCacheKey = "SovietTankEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public SovietTankRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(SovietTankEntityCacheKey);
        }

        public async Task<ICollection<SovietTankEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(SovietTankEntityCacheKey, out ICollection<SovietTankEntity> SovietTanksCached))
                return SovietTanksCached;

            var SovietTanksFromDb = await _context.SovietTanks.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(SovietTankEntityCacheKey, SovietTanksFromDb, cacheEntryOptions);
            return SovietTanksFromDb;
        }

        public async Task<SovietTankEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(SovietTankEntityCacheKey, out ICollection<SovietTankEntity> SovietTanksCached))
            {
                var SovietTankEntity = SovietTanksCached.FirstOrDefault(c => c.Id == id);
                if (SovietTankEntity != null)
                    return SovietTankEntity;
            }

            return await _context.SovietTanks.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.SovietTanks.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(SovietTankEntity SovietTankEntity)
        {
            _context.SovietTanks.Add(SovietTankEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(SovietTankEntity SovietTankEntity)
        {
            SovietTankEntity.CreatedDate = DateTime.Now;
            _context.Update(SovietTankEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var SovietTankEntity = await GetAsync(id);
            if (SovietTankEntity == null)
                return false;

            _context.SovietTanks.Remove(SovietTankEntity);
            return await Save();
        }
    }
}

