using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection.Tests
{
    public class MyEnumeratorTests
    {
        [Fact]
        public void MyEnumerator_Current_ValidIndex_ReturnsKeyValuePair()
        {
            var myDictionary = new MyDictionary<int, string>();
            myDictionary.Add(1, "One");
            var enumerator = myDictionary.GetEnumerator();

            enumerator.MoveNext();
            var currentKeyValuePair = enumerator.Current;

            Assert.Equal(new KeyValuePair<int, string>(1, "One"), currentKeyValuePair);
        }

        [Fact]
        public void MyEnumerator_Current_InvalidIndex_InvalidOperationException()
        {
            var myDictionary = new MyDictionary<int, string>();
            var enumerator = myDictionary.GetEnumerator();

            Func<object?> testCode = () => enumerator.Current;

            Assert.Throws<InvalidOperationException>(testCode);
        }

        [Fact]
        public void MyEnumerator_Reset_ResetsEnumeratorState()
        {
            // Arrange
            var myDictionary = new MyDictionary<int, string>();
            myDictionary.Add(1, "One");
            myDictionary.Add(2, "Two");
            myDictionary.Add(3, "Three");

            var enumerator = myDictionary.GetEnumerator();

            //Act
            while (enumerator.MoveNext())
            {
            }

            enumerator.Reset();

            // Assert
            Assert.True(enumerator.MoveNext());
            Assert.Equal(new KeyValuePair<int, string>(1, "One"), enumerator.Current);
        }
     }
}
