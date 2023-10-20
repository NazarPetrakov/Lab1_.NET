using Newtonsoft.Json.Linq;

namespace MyCollection.Tests
{
    public class MyCollectionPropTests
    {
        [Fact]
        public void IsReadOnlyProp_ShouldReturnFalse()
        {
            var myDictionary = new MyDictionary<int, string>();

            bool isReadOnly = myDictionary.IsReadOnly;

            Assert.False(isReadOnly);
        }
        [Fact]
        public void CountProp_ShouldBe3()
        {
            var myDictionary = new MyDictionary<int, string>()
            {
                {1, "one" },
                {2, "two"},
                {3, "three" }
            };

            var count = myDictionary.Count;

            Assert.Equal(3, count);
        }
        [Fact]
        public void KeysProp()
        {
            var myDictionary = new MyDictionary<int, string>()
            {
                {1, "one" },
                {2, "two"},
                {3, "three" }
            };

            var keys = myDictionary.Keys;

            Assert.Collection(keys, key =>
            {
                Assert.Equal(1, key);
            }, key =>
            {
                Assert.Equal(2, key);
            }, key =>
            {
                Assert.Equal(3, key);
            });
        }
        [Fact]
        public void ValuesProp()
        {
            var myDictionary = new MyDictionary<int, string>()
            {
                {1, "one" },
                {2, "two"},
                {3, "three" }
            };

            var values = myDictionary.Values;

            Assert.Collection(values, value =>
            {
                Assert.Equal("one", value);
            }, value =>
            {
                Assert.Equal("two", value);
            }, value =>
            {
                Assert.Equal("three", value);
            });
        }
    }
}
