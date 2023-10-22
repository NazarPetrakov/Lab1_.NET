using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Tests
{
    public class RemovingTests
    {
        [Fact]
        public void RemoveItem_NullKey_ArgumentNullException()
        {
            var myDictionary = new MyDictionary<object, object>();

            Action action = () => myDictionary.Remove(null!);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void RemoveItem_NotExistKey_KeyNotFoundException()
        {
            var myDictionary = new MyDictionary<int, string>();

            Action action = () => myDictionary.Remove(1);

            Assert.Throws<KeyNotFoundException>(action);
        }

        [Fact]
        public void RemoveItem_ExistingKey_RemovesKey()
        {
            var myDictionary = new MyDictionary<int, string>()
            {
                {1, "one" },
                {2, "two" },
                {3, "three"}
            };

            bool result = myDictionary.Remove(2);

            Assert.True(result);
            Assert.False(myDictionary.ContainsKey(2));
        }

        [Fact]
        public void RemoveKeyValue_NotExistPair_ReturnsFalse()
        {
            var myDictionary = new MyDictionary<int, string>();

            bool result = myDictionary.Remove(new KeyValuePair<int, string>(1, "One")); 

            Assert.False(result); 
        }

        [Fact]
        public void RemoveKeyValue_NullKey_ArgumentNullException()
        {
            var myDictionary = new MyDictionary<object, string>();

            Action action = () => myDictionary.Remove(new KeyValuePair<object, string>(null!, "One"));

            Assert.Throws<ArgumentNullException>(action);
        }
        [Fact]
        public void RemoveKeyValue_ExistingPair_RemovesPairAndReturnsTrue()
        {
            var myDictionary = new MyDictionary<int, string>()
            {
                { 1, "One"},
                { 2, "Two"}
            };

            bool result = myDictionary.Remove(new KeyValuePair<int, string>(1, "One"));

            Assert.True(result);
            Assert.False(myDictionary.ContainsKey(1));
        }
        [Fact]
        public void Clear_CountShouldBe0()
        {
            var myDictionary = new MyDictionary<int, string>()
            {
                { 1, "One"},
                { 2, "Two"}
            };

           myDictionary.Clear();

            Assert.Empty(myDictionary);
        }
    }
}
