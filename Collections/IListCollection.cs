using Penguin.SystemExtensions.Implementors;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Penguin.SystemExtensions.Collections
{
    public class IListCollection<T> : IList<T>, IList
    {
        protected IList<T> BackingList { get; set; } = new List<T>();

        private IListImplementor<T> iListImplementor;

        public virtual int Count => BackingList.Count;
        public virtual bool IsFixedSize => IListImplementor.IsFixedSize;
        public virtual bool IsReadOnly => BackingList.IsReadOnly;
        public virtual bool IsSynchronized => ((IList)IListImplementor).IsSynchronized;
        public virtual object SyncRoot => ((IList)IListImplementor).SyncRoot;

        protected IListImplementor<T> IListImplementor
        {
            get
            {
                iListImplementor ??= new IListImplementor<T>(this);
                return iListImplementor;
            }
            set => iListImplementor = value;
        }

        public virtual T this[int index] { get => BackingList[index]; set => BackingList[index] = value; }
        object IList.this[int index] { get => ((IList)IListImplementor)[index]; set => ((IList)IListImplementor)[index] = value; }

        public virtual void Add(T item)
        {
            BackingList.Add(item);
        }

        public virtual int Add(object value)
        {
            return ((IList)IListImplementor).Add(value);
        }

        public virtual void Clear()
        {
            BackingList.Clear();
        }

        public virtual bool Contains(T item)
        {
            return BackingList.Contains(item);
        }

        public virtual bool Contains(object value)
        {
            return ((IList)IListImplementor).Contains(value);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            BackingList.CopyTo(array, arrayIndex);
        }

        public virtual void CopyTo(Array array, int index)
        {
            ((IList)IListImplementor).CopyTo(array, index);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return BackingList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return BackingList.GetEnumerator();
        }

        public virtual int IndexOf(T item)
        {
            return BackingList.IndexOf(item);
        }

        public virtual int IndexOf(object value)
        {
            return ((IList)IListImplementor).IndexOf(value);
        }

        public virtual void Insert(int index, T item)
        {
            BackingList.Insert(index, item);
        }

        public virtual void Insert(int index, object value)
        {
            ((IList)IListImplementor).Insert(index, value);
        }

        public virtual bool Remove(T item)
        {
            return BackingList.Remove(item);
        }

        public virtual void Remove(object value)
        {
            ((IList)IListImplementor).Remove(value);
        }

        public virtual void RemoveAt(int index)
        {
            BackingList.RemoveAt(index);
        }
    }
}