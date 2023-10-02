namespace MyDictionary
{
    public class MyDictionaryEventArgs<TKey, TValue>: EventArgs
    {
        public TKey? key;
        public TValue? value;

        public MyDictionaryEventArgs(TKey key, TValue value) : base()
        {
            this.key = key;
            this.value = value;
        }
    }
}
