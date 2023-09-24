using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    internal class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private List<Entries<TKey, TValue>> _entries;
        private int[] _buckets;
        private int _capacity;
        private int _count;
        public MyDictionary() : this(0) { }
        public MyDictionary(int capacity)
        {
            _capacity = capacity;
            _buckets = new int[capacity];
            _entries = new List<Entries<TKey, TValue>>();
        }
        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }
       
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        private class MyEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private readonly MyDictionary<TKey, TValue> _dictionary;
            private int _pointer;
            public KeyValuePair<TKey, TValue> Current
            {
                get
                {
                    if (_pointer >= 0 && _pointer < _dictionary._entries.Count)
                    {
                        var entry = _dictionary._entries[_pointer];
                        return new KeyValuePair<TKey, TValue>(entry.key, entry.value);
                    }
                    throw new InvalidOperationException();
                }
            }

            object IEnumerator.Current => Current;

            public MyEnumerator(MyDictionary<TKey, TValue> dictionary)
            {
                _dictionary = dictionary;
                _pointer = -1;
            }

            public bool MoveNext()
            {
                _pointer++;

                return _pointer < _dictionary._entries.Count;
            }

            public void Reset()
            {
                _pointer = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
