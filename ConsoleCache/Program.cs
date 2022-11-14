using ConsoleCache.Cache;

Console.Write("Enter cache capacity: ");

if (!uint.TryParse(Console.ReadLine(), out var cacheCapacity))
{
    Console.WriteLine();
    throw new ArgumentOutOfRangeException("Cache capacity must be a positive integer");
};

var cache = new LruCache(Convert.ToInt32(cacheCapacity));

do 
{
    Console.Write("Enter a command (get | set | print): ");

    var command = Console.ReadLine()?.Split(" ");

    if (command?.Length == 2 
        && command[0].ToLowerInvariant() == "get" 
        && int.TryParse(command[1], out var keyToGet))
    {
        Console.WriteLine($"Retrieved {cache.Get(keyToGet)} from cache");
        Console.WriteLine();
    }
    else if (command?.Length == 3 
        && command[0].ToLowerInvariant() == "set" 
        && int.TryParse(command[1], out var keyToSet)
        && int.TryParse(command[2], out var value))
    {
        cache.Set(keyToSet, value);
        Console.WriteLine($"Set {keyToSet} with {value} to cache");
        Console.WriteLine();
    }
    else if (command?.Length == 1 
        && command[0].ToLowerInvariant() == "print") 
    {
        cache.PrintPairs();
    }
    else throw new ArgumentException("You passed some unexpected arguments to this command");

}
while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));
