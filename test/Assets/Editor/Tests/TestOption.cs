using N.Package.Optional;
using NUnit.Framework;

namespace Editor.Tests
{
    public class TestOption
    {
        [Test]
        public void TestOptionWithSome()
        {
            var value = Option.Some(100);
            Assert.True(value.Some);
        }

        [Test]
        public void TestOptionWithNone()
        {
            var value = Option.None<int>();
            Assert.True(value.None);
        }

        [Test]
        public void TestSafeAccess()
        {
            var value = Option.None<int>();
            value.With((v) => Assert.True(false)); // Unreachable

            var value2 = Option.Some(1);
            value2.With((v) => Assert.AreEqual(1, v));
        }
    }
}