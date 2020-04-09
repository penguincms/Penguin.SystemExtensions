using Penguin.SystemExtensions.Implementors;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Penguin.SystemExtensions.Collections
{
    public class IListCollection<T> : IList<T>, IList
    {
        protected IList<T> BackingList = new List<T>();

        private IListImplementor<T> iListImplementor;

        public virtual int Count => this.BackingList.Count;
        public virtual bool IsFixedSize => IListImplementor.IsFixedSize;
        public virtual bool IsReadOnly => this.BackingList.IsReadOnly;
        public virtual bool IsSynchronized => ((IList)this.IListImplementor).IsSynchronized;
        public virtual object SyncRoot => ((IList)this.IListImplementor).SyncRoot;

        protected IListImplementor<T> IListImplementor
        {
            get
            {
                if (iListImplementor is null)
                {
                    iListImplementor = new IListImplementor<T>(this);
                }
                return iListImplementor;
            }
            set => iListImplementor = value;
        }

        public virtual T this[int index] { get => BackingList[index]; set => BackingList[index] = value; }
        object IList.this[int index] { get => ((IList)this.IListImplementor)[index]; set => ((IList)this.IListImplementor)[index] = value; }

        public virtual void Add(T item)
        {
            this.BackingList.Add(item);
        }

        public virtual int Add(object value)
        {
            return ((IList)this.IListImplementor).Add(value);
        }

        public virtual void Clear()
        {
            this.BackingList.Clear();
        }

        public virtual bool Contains(T item)
        {
            return this.BackingList.Contains(item);
        }

        public virtual bool Contains(object value)
        {
            return ((IList)this.IListImplementor).Contains(value);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            this.BackingList.CopyTo(array, arrayIndex);
        }

        public virtual void CopyTo(Array array, int index)
        {
            ((IList)this.IListImplementor).CopyTo(array, index);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return this.BackingList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.BackingList.GetEnumerator();
        }

        public virtual int IndexOf(T item)
        {
            return this.BackingList.IndexOf(item);
        }

        public virtual int IndexOf(object value)
        {
            return ((IList)this.IListImplementor).IndexOf(value);
        }

        public virtual void Insert(int index, T item)
        {
            this.BackingList.Insert(index, item);
        }

        public virtual void Insert(int index, object value)
        {
            ((IList)this.IListImplementor).Insert(index, value);
        }

        public virtual bool Remove(T item)
        {
            return this.BackingList.Remove(item);
        }

        public virtual void Remove(object value)
        {
            ((IList)this.IListImplementor).Remove(value);
        }

        public virtual void RemoveAt(int index)
        {
            this.BackingList.RemoveAt(index);
        }
    }
}