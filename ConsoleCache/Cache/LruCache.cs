namespace ConsoleCache.Cache;

public class LruCache : ICache
{
    private record CachedValue
    {
        public required int Key { get; set; }
        public required int Value { get; set; }
    }

    private readonly Dictionary<int, CachedValue> _cache;
    private readonly LinkedList<CachedValue> _queue;

    public static int Capacity { get; private set; }

    public LruCache(int capacity = 2)
    {
        Capacity = capacity;
        _cache = new Dictionary<int, CachedValue>(Capacity);
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

    public void Set(int key, int value)
    {
        if (_cache.ContainsKey(key))
        {
            _cache[key] = _cache[key] with
            {
                Key = key,
                Value = value,
            };

            _queue.Remove(_cache[key]);
            _queue.AddFirst(_cache[key]);

            return;
        }

        if (_cache.Count >= Capacity && _queue.Last is not null)
        {
            _cache.Remove(_queue.Last.Value.Key);
            _queue.RemoveLast();
        }

        var cachedValue = new CachedValue 
        {
            Key = key,
            Value = value,
        };

        _cache.Add(key, cachedValue);
        _queue.AddFirst(cachedValue);
    }

    public void PrintPairs()
    {
        var i = 1;
        Console.WriteLine($"Cache count is {_cache.Count}");
        Console.WriteLine();

        foreach (var (Key, Value) in _cache)
        {
            Console.WriteLine($"Pair #{i}: Key = {Key}, Value = {Value.Value}");
            Console.WriteLine();
        }
    }
}