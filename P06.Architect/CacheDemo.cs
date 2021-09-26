using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P06.Architect
{
    public class CacheDemo
    {
        public void TestNative()
        {
            var _avatarCache = new NaiveCache<byte[]>();
            //var myAvatar = _avatarCache.GetOrCreate(userId, () => _database.GetAvatar(userId));
        }









    }



    public class NaiveCache<TItem>
    {
        Dictionary<object, TItem> _cache = new Dictionary<object, TItem>();

        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = createItem();
            }
            return _cache[key];
        }
    }
    public class SimpleMemoryCache<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = createItem();

                // Save data in cache.
                _cache.Set(key, cacheEntry);
            }
            return cacheEntry;
        }
    }

    public class MemoryCacheWithPolicy<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions()
        {
            SizeLimit = 1024
        });

        public TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            TItem cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = createItem();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSize(1)//Size amount
                    //Priority on removing when reaching size limit (memory pressure)
                    .SetPriority(CacheItemPriority.High)
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(2))
                    // Remove from cache after this time, regardless of sliding expiration
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                // Save data in cache.
                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;
        }
    }

    public class WaitToFinishMemoryCache<TItem>
    {
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();

        public async Task<TItem> GetOrCreate(object key, Func<Task<TItem>> createItem)
        {
            TItem cacheEntry;

            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                SemaphoreSlim mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();
                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        // Key not in cache, so get data.
                        cacheEntry = await createItem();
                        _cache.Set(key, cacheEntry);
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }
            return cacheEntry;
        }
    }



}
