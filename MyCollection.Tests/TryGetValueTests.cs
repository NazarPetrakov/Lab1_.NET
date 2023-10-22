using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Tests
{
    public class TryGetValueTests
    {
        [Fact]
        public void TryGetValue_KeyExists_ReturnsTrueAndValue()
        {
            var myDictionary = new MyDictionary<int, string>();
            myDictionary.Add(1, "One");

            bool result = myDictionary.TryGetValue(1, out var value);

            Assert.True(result);
            Assert.Equal("One", value);
        }

        [Fact]
        public void TryGetValue_KeyDoesNotExist_ReturnsFalseAndDefault()
        {
            var myDictionary = new MyDictionary<int, string>();

            bool result = myDictionary.TryGetValue(2, out var value);

            Assert.False(result);
            Assert.Null(value);
        }

        [Fact]
        public void TryGetValue_NullKey_ThrowsArgumentNullException()
        {
            var myDictionary = new MyDictionary<object, string>();

            Action action = () => myDictionary.TryGetValue(null!, out var value);

            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
