using ConsoleCache.Cache;
using System;
using Xunit;

namespace ConsoleCache.Tests.Cache
{
    public class LruCacheTests
    {
        [Fact]
        public void Get_Returns_Error_Code_When_Key_Is_Not_Cached()
        {
            // Arrange
            var lruCache = new LruCache(2);

            // Act
            var value = lruCache.Get(1);

            // Assert
            Assert.Equal(value, -1);
        }

        [Fact]
        public void Get_Returns_Error_Code_When_LRU_Key_Was_Evicted()
        {
            // Arrange
            var lruCache = new LruCache(2);

            // Act
            lruCache.Put(3, 2);
            lruCache.Put(1, 1);
            lruCache.Get(3);
            lruCache.Put(2, 2);
            var value = lruCache.Get(1);

            // Assert
            Assert.Equal(value, -1);
        }
    }
}
