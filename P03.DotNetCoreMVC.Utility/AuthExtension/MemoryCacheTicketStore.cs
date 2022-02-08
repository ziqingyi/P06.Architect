using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.Utility.AuthExtension
{
    public class MemoryCacheTicketStore: ITicketStore
    {
        private const string KeyPrefix = "MemoryCacheTicketStore-";

        //private IDistributedCache _cache;

        //public MemoryCacheTicketStore(IDistributedCache distributedCache)
        //{
        //    _cache = distributedCache;
        //}

        private IMemoryCache _cache;

        public MemoryCacheTicketStore(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public async Task<string> StoreAsync(AuthenticationTicket ticket)
        {
            var key = KeyPrefix + Guid.NewGuid().ToString("N");
            await RenewAsync(key, ticket);
            return key;
        }

        public Task RenewAsync(string key, AuthenticationTicket ticket)
        {
            var options = new MemoryCacheEntryOptions();
            var expireUtc = ticket.Properties.ExpiresUtc;
            if(expireUtc.HasValue)
            {
                options.SetAbsoluteExpiration(expireUtc.Value);
            }
            options.SetSlidingExpiration(TimeSpan.FromHours(1));
            _cache.Set(key, ticket, options);
            return Task.CompletedTask;
        }


        public Task<AuthenticationTicket> RetrieveAsync(string key)
        {
            _cache.TryGetValue(key, out AuthenticationTicket ticket);
            return Task.FromResult(ticket);
        }

        public Task RemoveAsync(string key)
        {
            _cache.Remove(key);
            return Task.CompletedTask;
        }







    }
}
