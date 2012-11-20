using System;
using System.Runtime.Caching;
using Greg.Lib.CodeSnippet;
using NUnit.Framework;

namespace Greg.Lib.Cache.MemoryCache
{
    public class Cache
    {
        private static System.Runtime.Caching.MemoryCache _cache;

        private static System.Runtime.Caching.MemoryCache GetInstance()
        {
            if (_cache == null)
            {
                _cache = new System.Runtime.Caching.MemoryCache("privateCache");
            }

            return _cache;
        }

        public static void Set(object item, string key)
        {
            GetInstance().Set(key, item, new CacheItemPolicy());
        }

        public static T Get<T>(string key)
        {
            var retObj = GetInstance()[key];

            return GenericConverter.ConvertObject<T>(retObj);
        }

        public static void Clear()
        {
            var cache = System.Runtime.Caching.MemoryCache.Default;

            cache.Trim(100);
        }

        public static void Initialize<T>(ICacheInitializer<T> initializer)
        {
            if(GetInstance().Contains(initializer.GetName()) == false)
            {
                GetInstance().Add(initializer.GetName(), initializer.GetObject(), new CacheItemPolicy());
            }
        }
    }
}
