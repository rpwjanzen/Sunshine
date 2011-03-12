using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Sunshine
{
    public sealed class ReadOnlyObservableCollection<T> : IList<T>, INotifyCollectionChanged
    {
        #region Fields

        private readonly ObservableCollection<T> m_source;

        #endregion

        #region Constructors

        public ReadOnlyObservableCollection(ObservableCollection<T> source)
        {
            m_source = source;
        }

        #endregion

        #region INotifyCollectionChanged Members

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { m_source.CollectionChanged += value; }
            remove { m_source.CollectionChanged -= value; }
        }

        #endregion

        #region IList<T> Members

        public int IndexOf(T item)
        {
            return m_source.IndexOf(item);
        }

        public bool Contains(T item)
        {
            return m_source.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            m_source.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return m_source.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public T this[int index]
        {
            get
            {
                return m_source[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        #region Not Supported Operations

        public void Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        #endregion
        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (m_source as IEnumerable).GetEnumerator();
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return m_source.GetEnumerator();
        }

        #endregion
    }
}
