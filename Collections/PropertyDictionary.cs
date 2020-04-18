using Penguin.SystemExtensions.Abstractions.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Penguin.SystemExtensions.Collections
{
    public class PropertyDictionary<TKey, TValue, TReturn> : IReadOnlyDictionary<TKey, TReturn>, IPropertyDictionary<TKey, TReturn>
    {
        IDictionary<TKey, TValue> backingDictionary;
        Func<TValue, TReturn> PropertyFunc;
        public PropertyDictionary(IDictionary<TKey, TValue> source, Func<TValue, TReturn> propertyFunc)
        {
            backingDictionary = source;
            PropertyFunc = propertyFunc;
        }

        public TReturn this[TKey key] { get => PropertyFunc(backingDictionary[key]); }

        public IEnumerable<TKey> Keys => backingDictionary.Keys;
        public IEnumerable<TReturn> Values
        {
            get
            {
                foreach (KeyValuePair<TKey, TValue> kvp in backingDictionary)
                {
                    yield return PropertyFunc(kvp.Value);
                }
            }
        }
        public int Count => backingDictionary.Count;

        public bool ContainsKey(TKey key) => backingDictionary.ContainsKey(key);
        public IEnumerator<KeyValuePair<TKey, TReturn>> GetEnumerator()
        {
            foreach (KeyValuePair<TKey, TValue> kvp in backingDictionary)
            {
                yield return new KeyValuePair<TKey, TReturn>(kvp.Key, PropertyFunc(kvp.Value));
            }
        }

        public bool TryGetValue(TKey key, out TReturn value)
        {
            if (backingDictionary.TryGetValue(key, out TValue v))
            {
                value = PropertyFunc(v);
                return true;
            }
            value = default;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }
}
