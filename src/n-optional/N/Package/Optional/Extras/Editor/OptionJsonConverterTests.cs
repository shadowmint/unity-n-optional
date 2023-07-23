#if N_PACKAGE_OPTIONAL
using N.Package.Optional.Extras;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;

namespace N.Package.Optional.Editor
{
    public class OptionJsonConverterTests
    {
        public class Bar
        {
            public int Value { get; set; } = 10;
        }

        public class Foo
        {
            [JsonConverter(typeof(OptionJsonConverter<Bar>))]
            public Option<Bar> Value { get; set; }
        }

        [Test]
        public void TestOptionJsonSerialization_WithSome()
        {
            var a = new Foo()
            {
                Value = Option.Some(new Bar()
                {
                    Value = 10
                })
            };

            var b = JsonConvert.SerializeObject(a);
            
            var c = JsonConvert.DeserializeObject<Foo>(b);
            Assert.IsTrue(c.Value.Some);
            Assert.AreEqual(10, c.Value.Unwrap().Value);
        }
    }
}
#endif