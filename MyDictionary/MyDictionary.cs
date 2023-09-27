﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;

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

        public ICollection<TKey> Keys => GetCollection(entry => entry.key);        

        public ICollection<TValue> Values => GetCollection(entry => entry.value)!;

        public int Count => _count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (ContainsKey(key))
                throw new ArgumentException("An item with the same key already exists in the dictionary.");

            uint hashCode = (uint)key.GetHashCode();
            int bucketIndex = GetBucketIndex(hashCode);
            int entryIndex = -1;

            if (_count >= _capacity)
                Resize();

            for (int i = 0; i < _entries.Length; i++)
            {
                if (_entries[i] == null)
                {
                    entryIndex = i;
                    break;
                }
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
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            uint hashCode = (uint)key.GetHashCode();
            int bucketIndex = GetBucketIndex(hashCode);
            int entryIndex = _buckets[bucketIndex] - 1;
            int next = -2;

            if(entryIndex <= -1)
                return false;

            do
            {
                Entry<TKey, TValue> entry = _entries[entryIndex];
                next = entry.next;
                if (hashCode == entry.hashCode)
                    return true;
                entryIndex = next;
            } while (next != -1);

            return false;
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

        private void Resize()
        {
            int newCapacity = GetNextPrime(_capacity);
            var newEntries = new Entry<TKey, TValue>[newCapacity];
            _buckets = new int[newCapacity];

            Array.Copy(_entries, newEntries, _count);
            
            for (int i = 0; i < newCapacity; i++)
            {
                if (newEntries[i] is null)
                    break;
                NewBucketsIndexes(newEntries, i);
            }
            _entries = newEntries;
            _capacity = newCapacity;
        }
        private void NewBucketsIndexes(Entry<TKey, TValue>[] newEntries, int i)
        {
            uint hashCode = newEntries[i].hashCode;
            int bucketIndex = GetBucketIndex(hashCode);
            newEntries[i].next = _buckets[bucketIndex] - 1;
            _buckets[bucketIndex] = i + 1;
        }
        private int GetBucketIndex(uint hashCode)
        {
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
        private ICollection<T> GetCollection<T>(Func<Entry<TKey, TValue>, T> selector)
        {
            List<T> collection = new List<T>(_count);
            foreach (var entry in _entries)
            {
                if (entry != null)
                {
                    T selectedValue = selector(entry);
                    collection.Add(selectedValue);
                }
            }
            return collection;
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
                    }
                    throw new InvalidOperationException();
                }
            }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                _pointer++;

                while (_pointer < _dictionary._entries.Length)
                {
                    var entry = _dictionary._entries[_pointer];
                    if (entry != null)
                    {
                        return true;
                    }
                    _pointer++;
                }
                return false;
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
