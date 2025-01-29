using RestAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Repository
{
    public class HouseRepository : IHouseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string HouseEntityCacheKey = "HouseEntityCacheKey"; //cambiadmelo lokos
        private readonly int CacheExpirationTime = 3600;
        public HouseRepository(ApplicationDbContext context, IMemoryCache cache)
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
            _cache.Remove(HouseEntityCacheKey);
        }

        public async Task<ICollection<HouseEntity>> GetAllAsync()
        {
            if (_cache.TryGetValue(HouseEntityCacheKey, out ICollection<HouseEntity> HousesCached))
                return HousesCached;

            var HousesFromDb = await _context.Houses.OrderBy(c => c.Name).ToListAsync();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(CacheExpirationTime));

            _cache.Set(HouseEntityCacheKey, HousesFromDb, cacheEntryOptions);
            return HousesFromDb;
        }

        public async Task<HouseEntity> GetAsync(int id)
        {
            if (_cache.TryGetValue(HouseEntityCacheKey, out ICollection<HouseEntity> HousesCached))
            {
                var HouseEntity = HousesCached.FirstOrDefault(c => c.Id == id);
                if (HouseEntity != null)
                    return HouseEntity;
            }

            return await _context.Houses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Houses.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(HouseEntity HouseEntity)
        {
            HouseEntity.CreatedDate = DateTime.Now;
            _context.Houses.Add(HouseEntity);
            return await Save();
        }

        public async Task<bool> UpdateAsync(HouseEntity HouseEntity)
        {
            _context.Update(HouseEntity);
            return await Save();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var HouseEntity = await GetAsync(id);
            if (HouseEntity == null)
                return false;

            _context.Houses.Remove(HouseEntity);
            return await Save();
        }
    }
}
