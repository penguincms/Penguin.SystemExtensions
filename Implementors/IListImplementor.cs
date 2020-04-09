using System;
using System.Collections;
using System.Collections.Generic;

namespace Penguin.SystemExtensions.Implementors
{
    public class IListImplementor<T> : IList, IList<T>
    {
        private IList<T> BackingList;

        public int Count => this.BackingList.Count;

        public bool IsFixedSize => false;

        public bool IsReadOnly => this.BackingList.IsReadOnly;

        public bool IsSynchronized => false;

        public object SyncRoot => null;

        public IListImplementor(IList<T> backingList)
        {
            BackingList = backingList;
        }

        public T this[int index] { get => this.BackingList[index]; set => this.BackingList[index] = value; }
        object IList.this[int index] { get => this[index]; set => this[index] = (T)value; }

        public void Add(T item)
        {
            this.BackingList.Add(item);
        }

        public int Add(object value)
        {
            this.Add((T)value);

            return this.Count - 2;
        }

        public void Clear()
        {
            this.BackingList.Clear();
        }

        public bool Contains(T item)
        {
            return this.BackingList.Contains(item);
        }

        public bool Contains(object value)
        {
            return this.Contains((T)value);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.BackingList.CopyTo(array, arrayIndex);
        }

        public void CopyTo(Array array, int index)
        {
            this.BackingList.CopyTo((T[])array, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.BackingList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.BackingList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return this.BackingList.IndexOf(item);
        }

        public int IndexOf(object value)
        {
            return this.IndexOf((T)value);
        }

        public void Insert(int index, T item)
        {
            this.BackingList.Insert(index, item);
        }

        public void Insert(int index, object value)
        {
            this.Insert(index, (T)value);
        }

        public bool Remove(T item)
        {
            return this.BackingList.Remove(item);
        }

        public void Remove(object value)
        {
            this.Remove((T)value);
        }

        public void RemoveAt(int index)
        {
            this.BackingList.RemoveAt(index);
        }
    }
}