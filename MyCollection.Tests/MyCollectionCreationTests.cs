using MyDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Tests
{
    public class MyCollectionCreationTests
    {
        [Fact]
        public void CreateMyDictionary_WithoutParams_EmptyDictionary() 
        {
            MyDictionary<object, object> myDictionary;

            myDictionary = new MyDictionary<object, object>();

            Assert.Empty(myDictionary);
        }
        [Fact]
        public void CreateMyDictionary_CapacityLessThanZero_ArgumentOutOfRangeException()
        {
            MyDictionary<object, object> myDictionary;

            var action = () => { myDictionary = new MyDictionary<object, object>(-5); };

            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
        [Fact]
        public void CreateMyDictionary_ZeroCapacity_EmptyDictionary()
        {
            MyDictionary<object, object> myDictionary;

            myDictionary = new MyDictionary<object, object>(0);

            Assert.Empty(myDictionary);
        }
    }
}
