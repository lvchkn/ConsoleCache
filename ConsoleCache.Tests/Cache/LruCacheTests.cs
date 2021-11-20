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
    }
}
