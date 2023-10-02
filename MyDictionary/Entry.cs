namespace MyDictionary
{
    internal class Entry<TKey, TValue>
    {
        public TKey key;
        public TValue? value;
        public int next;
        public uint hashCode;
    }
}
