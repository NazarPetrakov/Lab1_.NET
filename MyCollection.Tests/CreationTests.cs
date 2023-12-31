﻿namespace MyCollection.Tests
{
    public class CreationTests
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
        [Fact]
        public void CreateMyDictionary_InitialCapacity_ShouldBeResized()
        {
            int initialCapacity = 10;

            var myDictionary = new MyDictionary<int, string>(initialCapacity);
            for (int i = 0; i < initialCapacity + 1; i++)
            {
                myDictionary.Add(i, $"Value{i}");
            }

            Assert.True(myDictionary.Count > initialCapacity);
        }
    }
}
