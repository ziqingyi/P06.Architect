using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using P03.DotNetCoreMVC.Utility.Interface;

namespace P03.DotNetCoreMVC.Utility.Extensions
{
    public class MyMemoryCacheCore : ICache
    {
        public MyMemoryCacheCore()
        {

        }

        protected ObjectCache Cache
        {
            get
            {
                return System.Runtime.Caching.MemoryCache.Default;
            }
        }

        public T Get<T>(string key)
        {
            if (Cache.Contains(key))
            {
                object res = Cache[key];
                return (T)res;
            }
            else
            {
                return default(T);
            }
        }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Add(string key, object data, int cacheTime = 30)
        {
            if (data == null)
            {
                return;
            }

            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);

            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool Contains(string key)
        {
            return Cache.Contains(key);
        }

        public int Count
        {
            get
            {
                int num = (int)Cache.GetCount();
                return num;
            }
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            Regex reg = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            List<string> keysToRemove = new List<string>();

            foreach (KeyValuePair<string, object> item in Cache)
            {
                if (reg.IsMatch(item.Key))
                {
                    keysToRemove.Add(item.Key);
                }
            }

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        public object this[string key]
        {
            get
            {
                return Cache.Get(key);
            }
            set
            {
                Add(key, value);
            }
        }


        public void RemoveAll()
        {
            foreach (KeyValuePair<string, object> item in Cache)
            {
                Remove(item.Key);
            }

        }


    }
}
