namespace MyCollection.Tests
{
    public class MyCollectionAddingTests
    {
        [Fact]
        public void AddItem_NullKey_ArgumentNullException()
        {
            MyDictionary<object, object> myDictionary = new MyDictionary<object, object>();

            var action = () => myDictionary.Add(null!, 2);

            Assert.Throws<ArgumentNullException>(action);
        }
        [Fact]
        public void AddItem_KeyAlreadyExist_ArgumentException()
        {
            MyDictionary<object, object> myDictionary = new MyDictionary<object, object>();

            var action = () =>
            {
                myDictionary.Add(4, "four");
                myDictionary.Add(4, "five");
            };

            Assert.Throws<ArgumentException>(action);
        }
        [Theory]
        [MemberData(nameof(TestDataGenerator.GetNumbersFromDataGenerator), MemberType = typeof(TestDataGenerator))]
        public void AddItems_ValidData_CollectionWithItems(KeyValuePair<object, object> kvp1, KeyValuePair<object, object> kvp2)
        {
            MyDictionary<object, object> myDictionary = new MyDictionary<object, object>();

            myDictionary.Add(kvp1);
            myDictionary.Add(kvp2);

            Assert.Equal(kvp1.Value, myDictionary[kvp1.Key]);
            Assert.True(myDictionary.ContainsKey(kvp2.Key));
            
        }
    }
}
