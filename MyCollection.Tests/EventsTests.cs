namespace MyCollection.Tests
{
    public class EventsTests
    {
        [Fact]
        public void AddedPairEvent()
        {
            bool isEventTriggered = false;
            var myDictionary = new MyDictionary<int, string>
            {
                { 1, "One" },
            };

            myDictionary.AddedPair += (sender, args) =>
                isEventTriggered = true;
            myDictionary.Add(2, "Two");

            Assert.True(isEventTriggered);
        }
        [Fact]
        public void RemovedPairEvent()
        {
            bool isEventTriggered = false;
            var myDictionary = new MyDictionary<int, string>
            {
                { 1, "One" },
            };

            myDictionary.RemovedPair += (sender, args) =>
                isEventTriggered = true;
            myDictionary.Remove(1);

            Assert.True(isEventTriggered);
        }
        [Fact]
        public void ChangedValueEvent()
        {
            bool isEventTriggered = false;
            var myDictionary = new MyDictionary<int, string>
            {
                { 1, "One" },
            };

            myDictionary.ChangedValue += (sender, args) =>
                isEventTriggered = true;
            myDictionary[1] = "!ONE!";

            Assert.True(isEventTriggered);
        }
        [Fact]
        public void ClearedEvent()
        {
            bool isEventTriggered = false;
            var myDictionary = new MyDictionary<int, string>
            {
                { 1, "One" },
            };

            myDictionary.Cleared += (sender, args) =>
                isEventTriggered = true;
            myDictionary.Clear();

            Assert.True(isEventTriggered);
        }
    }
}
