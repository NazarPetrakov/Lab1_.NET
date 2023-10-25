namespace MyCollection.Tests
{
    public class CopyToTests
    {
        [Fact]
        public void CopyTo_CopiesElementsToDestinationArray()
        {
            var myDictionary = new MyDictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" }
            };
            var array = new KeyValuePair<int, string>[3];

            myDictionary.CopyTo(array, 0);

            Assert.Equal(new KeyValuePair<int, string>(1, "One"), array[0]);
            Assert.Equal(new KeyValuePair<int, string>(2, "Two"), array[1]);
            Assert.Equal(new KeyValuePair<int, string>(3, "Three"), array[2]);
        }

        [Fact]
        public void CopyTo_NullArray_ArgumentNullException()
        {
            var myDictionary = new MyDictionary<int, string>();
            var array = (KeyValuePair<int, string>[])null!;

            Action action = () => myDictionary.CopyTo(array, 0);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void CopyTo_NegativeArrayIndex_ArgumentOutOfRangeException()
        {
            var myDictionary = new MyDictionary<int, string>();
            var array = new KeyValuePair<int, string>[3];

            Action action = () => myDictionary.CopyTo(array, -1);

            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void CopyTo_ArrayIndexOutOfRange_ArgumentOutOfRangeException()
        {
            var myDictionary = new MyDictionary<int, string>();
            var array = new KeyValuePair<int, string>[3];

            Action action = () => myDictionary.CopyTo(array, 5);

            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void CopyTo_ArrayTooSmall_ArgumentException()
        {
            var myDictionary = new MyDictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" }
            };
            var array = new KeyValuePair<int, string>[1];

            Action action = () => myDictionary.CopyTo(array, 0);

            Assert.Throws<ArgumentException>(action);
        }
    }
}
