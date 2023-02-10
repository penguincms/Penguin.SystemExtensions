using System;
using System.Collections;
using System.Collections.Generic;

namespace Penguin.SystemExtensions.Implementors
{
    public class IListImplementor<T> : IList, IList<T>
    {
        private readonly IList<T> BackingList;

        public int Count => BackingList.Count;

        public bool IsFixedSize => false;

        public bool IsReadOnly => BackingList.IsReadOnly;

        public bool IsSynchronized => false;

        public object SyncRoot => null;

        public IListImplementor(IList<T> backingList)
        {
            BackingList = backingList;
        }

        public T this[int index] { get => BackingList[index]; set => BackingList[index] = value; }
        object IList.this[int index] { get => this[index]; set => this[index] = (T)value; }

        public void Add(T item)
        {
            BackingList.Add(item);
        }

        public int Add(object value)
        {
            Add((T)value);

            return Count - 2;
        }

        public void Clear()
        {
            BackingList.Clear();
        }

        public bool Contains(T item)
        {
            return BackingList.Contains(item);
        }

        public bool Contains(object value)
        {
            return Contains((T)value);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            BackingList.CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            BackingList.CopyTo((T[])array, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return BackingList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return BackingList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return BackingList.IndexOf(item);
        }

        public int IndexOf(object value)
        {
            return IndexOf((T)value);
        }

        public void Insert(int index, T item)
        {
            BackingList.Insert(index, item);
        }

        public void Insert(int index, object value)
        {
            Insert(index, (T)value);
        }

        public bool Remove(T item)
        {
            return BackingList.Remove(item);
        }

        public void Remove(object value)
        {
            _ = Remove((T)value);
        }

        public void RemoveAt(int index)
        {
            BackingList.RemoveAt(index);
        }
    }
}