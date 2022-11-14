namespace ConsoleCache.Cache;

public interface ICache
{
    void Set(int key, int value);
    int Get(int key);
    void PrintPairs();
}