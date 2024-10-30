using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Code.Infrastructure.Pool.Tests
{
    public class ObjectPoolTests
    {
        [Test]
        public void WhenObjectPooling_ThenObjectInPool()
        {
            // arrange
            IPoolable poolable = Substitute.For<IPoolable>();
            IObjectPool pool = new ObjectPool();
            
            // act
            pool.Release<IPoolable>(poolable);
            
            // assert
            pool.GetSize<IPoolable>().Should().Be(1);
        }
        
        [Test]
        public void WhenObjectRentFromPool_ThenRentingSuccessful()
        {
            // arrange
            IPoolable poolable = Substitute.For<IPoolable>();
            IObjectPool pool = new ObjectPool();
            
            // act
            pool.Release<IPoolable>(poolable);
            bool rentResult = pool.TryRent(out IPoolable pooled);
            
            // assert
            rentResult.Should().BeTrue();
            pooled.Should().NotBeNull();
        }
    }
}
