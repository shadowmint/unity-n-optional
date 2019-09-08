using System;
using System.Threading.Tasks;
using N.Package.Optional;
using NUnit.Framework;

namespace Editor.Tests
{
    public class TestFailureConditions
    {
        [Test]
        public void TestWithErrorShouldRaiseException()
        {
            var harness = Option.Some(new TestHarness());
            Assert.Throws<Exception>(() => { harness.With((t) => { t.TestFailure(); }); });
        }

        [Test]
        public void TestValueErrorShouldRaiseException()
        {
            var harness = Option.Some(new TestHarness());
            
            // With no value, the default is returned.
            var defaultValue = Option.None<TestHarness>().WithValue((v) => throw new Exception(), 1);
            Assert.AreEqual(defaultValue, 1);
            
            // An exception in the resolver does *not* return the default, it raises the exception.
            Assert.Throws<Exception>(() =>
            {
                harness.WithValue((t) =>
                {
                    t.TestFailure();
                    return 0;
                }, 1);
            });
        }
        
        [Test]
        public void TestWithAsyncErrorShouldRaiseException()
        {
            var harness = Option.Some(new TestHarness());
            Assert.Throws<AggregateException>(() => { harness.WithAsync(async (t) => { await t.TestFailureAsync(); }).Wait(); });
        }

        [Test]
        public void TestValueAsyncErrorShouldRaiseException()
        {
            var harness = Option.Some(new TestHarness());
            
            // With no value, the default is returned.
            var defaultValue = Option.None<TestHarness>().WithValueAsync((v) => throw new Exception(), 1).Result;
            Assert.AreEqual(defaultValue, 1);
            
            // An exception in the resolver does *not* return the default, it raises the exception.
            Assert.Throws<AggregateException>(() =>
            {
                harness.WithValueAsync(async t =>
                {
                    await t.TestFailureAsync();
                    return 0;
                }, 1).Wait();
            });
        }
      
        private class TestHarness
        {
            public void TestFailure()
            {
                throw new Exception("Error");
            }


            public Task TestFailureAsync()
            {
                return Task.FromException(new Exception("Error"));
            }
        }
    }
}