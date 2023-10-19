using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDictionary;

namespace MyCollection.Tests
{
    public class MyCollectionIndexerTest
    {
        [Fact]
        public void GetValueIndexer_ValueByKey1_One()
        {
            var myDictionary = new Dictionary<int, string>
            {
                { 1, "One" }
            };

            var a = myDictionary[1];

            Assert.Equal("One", a);

        }
        [Fact]
        public void GetValueIndexer_ValueByKey2_KeyNotFoundException()
        {
            var myDictionary = new MyDictionary<int, string>
            {
                { 1, "One" }
            };

            var action = () => myDictionary[2];

            Assert.Throws<KeyNotFoundException>(action);

        }
        [Fact]
        public void SetValueIndexer_ValueTwoByKey2_NewItem()
        {
            var myDictionary = new MyDictionary<int, string>
            {
                { 1, "One" }
            };

            myDictionary[1] = "ONE";

            Assert.Equal("ONE", myDictionary[1]);

        }

        [Fact]
        public void SetValueIndexer_NullKey_ArgumentNullException()
        {
            var myDictionary = new MyDictionary<object, object>
            {
                { 1, "One" }
            };

            var action = () => myDictionary[null!] = "ONE";

            Assert.Throws<ArgumentNullException>(action);

        }

        [Fact]
        public void SetValueIndexer_NotExistKey2_KeyNotFoundException()
        {
            var myDictionary = new MyDictionary<object, object>
            {
                { 1, "One" }
            };

            var action = () => myDictionary[2] = "ONE";

            Assert.Throws<KeyNotFoundException>(action);

        }

    }
}
