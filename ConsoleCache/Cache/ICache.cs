namespace ConsoleCache.Cache
{
    public interface ICache
    {
        public void Put(int key, int value);
        public int Get(int key);
    }
}
