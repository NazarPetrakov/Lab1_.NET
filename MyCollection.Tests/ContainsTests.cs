using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Tests
{
    public class ContainsTests
    {
        [Fact]
        public void ContainsKeyValue_ExistingPair_ReturnsTrue()
        {
            var myDictionary = new MyDictionary<int, string>();
            myDictionary.Add(1, "One");

            bool result = myDictionary.Contains(new KeyValuePair<int, string>(1, "One"));

            Assert.True(result);
        }

        [Fact]
        public void ContainsKeyValue_NotExistPair_ReturnsFalse()
        {
            var myDictionary = new MyDictionary<int, string>();

            bool result = myDictionary.Contains(new KeyValuePair<int, string>(1, "One"));

            Assert.False(result);
        }

        [Fact]
        public void Contains_NullKey_ThrowsArgumentNullException()
        {
            var myDictionary = new MyDictionary<object, string>();

            Action action = () => myDictionary.Contains(new KeyValuePair<object, string>(null!, "One"));

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void ContainsKey_ExistingKey_ReturnsTrue()
        {
            var myDictionary = new MyDictionary<int, string>();
            myDictionary.Add(1, "One");

            bool result = myDictionary.ContainsKey(1);

            Assert.True(result);
        }

        [Fact]
        public void ContainsKey_NonExistentKey_ReturnsFalse()
        {
            var myDictionary = new MyDictionary<int, string>();

            bool result = myDictionary.ContainsKey(1);

            Assert.False(result); 
        }

        [Fact]
        public void ContainsKey_NullKey_ThrowsArgumentNullException()
        {
            var myDictionary = new MyDictionary<object, string>();

            Action action = () => myDictionary.ContainsKey(null!);

            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
