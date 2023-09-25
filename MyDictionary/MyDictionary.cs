using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MyDictionary
{
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Entry<TKey, TValue>[] _entries;
        private int[] _buckets;
        private int _capacity;
        private int _count = 0;
        public MyDictionary() : this(3) { }
        public MyDictionary(int capacity)
        {
            if(capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            if(capacity is 0)
            {
                _buckets = Array.Empty<int>();
                _entries = Array.Empty<Entry<TKey, TValue>>();
            }
            _buckets = new int[capacity];
            _entries = new Entry<TKey, TValue>[capacity];
            _capacity = capacity;
        }
        public TValue this[TKey key]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ICollection<TKey> Keys => (ICollection<TKey>)_entries.Select(e => e.key);

        public ICollection<TValue> Values => (ICollection<TValue>)_entries.Select(e => e.value);

        public int Count => _count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            //if (ContainsKey(key))
            //{
            //    throw new ArgumentException("An item with the same key already exists in the dictionary.");
            //}

            uint hashCode = (uint)key.GetHashCode();
            int bucketIndex = GetBucketIndex(hashCode);
            int entryIndex = -1;
           
            for (int i = 0; i < _entries.Length; i++)
            {
                if (_entries[i] == null)
                {
                    entryIndex = i;
                    break;
                }
            }
            if (_count >= _capacity || entryIndex is -1)
            {
                Resize();
            }
            _entries[entryIndex] = new Entry<TKey, TValue>
            {
                key = key,
                value = value,
                hashCode = hashCode,
                next = _buckets[bucketIndex] - 1
            };
            _buckets[bucketIndex] = entryIndex + 1;
            _count++;
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
            return GetEnumerator();
        }
        private int GetBucketIndex(uint hashCode)
        {
            //int bucketIndex = (int)(hashCode % _buckets.Length);

            //if (bucketIndex < 0)
            //{
            //    bucketIndex += _buckets.Length;
            //}

            return (int)(hashCode % _buckets.Length);
        }
        private int GetNextPrime(int currentCapacity)
        {
            bool IsPrime(int number)
            {
                if (number <= 1) return false;
                if (number == 2 || number == 3) return true;
                if (number % 2 == 0) return false;

                int sqrt = (int)Math.Sqrt(number);
                for (int i = 3; i <= sqrt; i += 2)
                {
                    if (number % i == 0)
                        return false;
                }
                return true;
            }

            int newCapacity = currentCapacity * 2;
            while (true)
            {
                if (IsPrime(newCapacity))
                    return newCapacity;
                newCapacity++;
            }
        }
        private void Resize()
        {
            int newCapacity = GetNextPrime(_capacity);
            int[] newBuckets = new int[newCapacity];
            Entry<TKey, TValue>[] entries = new Entry<TKey, TValue>[newCapacity];

            Array.Copy(_buckets, newBuckets, _count);
            _buckets = newBuckets;
            _capacity = newCapacity;
        }

        private class MyEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private readonly MyDictionary<TKey, TValue> _dictionary;
            private int _pointer;

            public MyEnumerator(MyDictionary<TKey, TValue> dictionary)
            {
                _dictionary = dictionary;
                _pointer = -1;
            }

            public KeyValuePair<TKey, TValue> Current
            {
                get
                {
                    if (_pointer >= 0 && _pointer < _dictionary._entries.Length)
                    {
                        var entry = _dictionary._entries[_pointer];
                        if (entry != null)
                            return new KeyValuePair<TKey, TValue>(entry.key, entry.value!);
                        else
                            return default;
                            
                        
                    }
                    throw new InvalidOperationException();
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                _pointer++;

                return _pointer < _dictionary._entries.Length;
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
