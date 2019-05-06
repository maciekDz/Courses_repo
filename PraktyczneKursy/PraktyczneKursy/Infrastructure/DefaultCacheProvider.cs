﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace PraktyczneKursy.Infrastructure
{
    public class DefaultCacheProvider : ICacheProvider
    {
        private Cache Cache{get{ return HttpContext.Current.Cache; } }
        public object Get(string key)
        {
            return Cache[key];
        }
        public void Set(string key, object data, int cacheTime)
        {
            var expirationTime = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Insert(key, data, null, expirationTime, Cache.NoSlidingExpiration);
        }
        public bool IsSet(string key)
        {
            return (Cache[key] != null);
        }
        public void Invalidate(string key)
        {
            Cache.Remove(key);
        }

    }
}