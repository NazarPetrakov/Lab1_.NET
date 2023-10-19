namespace MyCollection.Tests
{
    internal class TestDataGenerator
    {
        public static IEnumerable<object[]> GetNumbersFromDataGenerator()
        {
            yield return new object[] { 
                new KeyValuePair<object, object>(1, "one" ),
                new KeyValuePair<object, object>(-1, "minus one" ),
            };
            yield return new object[] {
                new KeyValuePair<object, object>("one", 1 ),
                new KeyValuePair<object, object>("ONE", 1 ),
            };
        }
    }
}
