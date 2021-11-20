using System;
using System.Collections.Generic;

namespace ConsoleCache.Cache
{
    public class LruCache : ICache
    {
        class CachedValue
        {
            public int Key { get; set; }
            public int Value { get; set; }

            public CachedValue(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly Dictionary<int, CachedValue> _cache;
        private readonly LinkedList<CachedValue> _queue;

        public static int Capacity { get; private set; }

        public LruCache(int capacity = 2)
        {
            Capacity = capacity;
            _cache = new Dictionary<int, CachedValue>(capacity);
            _queue = new LinkedList<CachedValue>();
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                return -1;
            }

            var cachedValue = _cache[key];
            _queue.Remove(cachedValue);
            _queue.AddFirst(cachedValue);

            return _cache[key].Value;
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key))
            {
                _cache[key].Key = key;
                _cache[key].Value = value;
                _queue.Remove(_cache[key]);
                _queue.AddFirst(_cache[key]);
                return;
            }
            
            if (_cache.Count >= Capacity)
            {
                _cache.Remove(_queue.Last.Value.Key);
                _queue.RemoveLast();
            }

            var cachedValue = new CachedValue(key, value);
            _cache.Add(key, cachedValue);
            _queue.AddFirst(cachedValue);
        }

        public void PrintCachedKeyValuePairs()
        {
            var i = 0;

            foreach (KeyValuePair<int, CachedValue> kvp in _cache)
            {
                Console.WriteLine($"Cached key #{i} = {kvp.Key}");
                Console.WriteLine($"Cached value #{i++} = {kvp.Value.Value}");
                Console.WriteLine();
            }
        }
    }
}
