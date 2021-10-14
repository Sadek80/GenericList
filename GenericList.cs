using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Generic_List
{
    /// <summary>
    /// Generic Class that represents C# List<T> 
    /// </summary>
    /// <typeparam name="T"> A generic value</typeparam>
    class GenericList<T> : IEnumerable, IEnumerator
    {
        // The basic Array to hold the elements
        T[] arr;

        // The initial Position of the List, provided to enabling iteration through Foreach
        private int positon = -1;

        /// <summary>
        /// Return number of element on the list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets or Sets the total number of elements that the structure can hold without resizing
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Initialize a new instance that is empty and has the default capacity
        /// </summary>
        public GenericList()
        {
            arr = new T[4];
            Capacity = 4;
            Count = 0;
        }

        /// <summary>
        /// Initialize a new instance that is empty and has the specified initial capacity
        /// </summary>
        /// <param name="capacity"></param>
        public GenericList(int capacity)
        {
            arr = new T[capacity];
            Capacity = capacity;
            Count = 0;
        }

        /// <summary>
        /// Add new element to te list
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            try
            {
                if (Count < Capacity)
                {
                    arr[Count] = value;
                    Count++;
                }
                else
                {
                    ExpandSize();
                    arr[Count] = value;
                    Count++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Resizing the Array
        /// </summary>
        private void ExpandSize()
        {
            // we can use Resize function either:
            //Array.Resize(ref arr, Capacity * 2);

            var temp = arr;
            arr = new T[Capacity * 2];

            for (int i = 0; i < temp.Length; i++)
            {
                arr[i] = temp[i];
            }

            Capacity *= 2;
        }

        /// <summary>
        /// Gets or Sets the value at the specified elements
        /// </summary>
        /// <param name="index">index of the element</param>
        /// <returns>The value at the specified index</returns>
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index Out Of Range");

                return arr[index];
            }
        }

        /// <summary>
        /// Remove the element that has the specified value
        /// </summary>
        /// <param name="value">the element value</param>
        /// <returns>returns True if the element successfully deleted, and False if not. Also returns false if the element is not found </returns>
        public bool Remove(T value)
        {
            bool flag = false;
            int index = 0;
            foreach (var item in arr)
            {
                if (index == Count  || Count == 0)
                    break;

                if (item.Equals(value))
                {
                    flag = true;
                    continue;
                }
                else
                {
                    arr[index] = item;
                    index++;
                }

            }
            if (flag)
            {
                arr[Count - 1] = default(T);
                Count--;
            }

            return flag;
        }

        /// <summary>
        /// Remove the element at the specified index
        /// </summary>
        /// <param name="index">the index of the element</param>
        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index Out Of Rnage");

            Remove(arr[index]);
        }

        /// <summary>
        /// Clear all the list
        /// </summary>
        public void clear()
        {
            arr = new T[Capacity];
            Count = 0;
        }

        /// <summary>
        /// Check if their is an element of the specified value
        /// </summary>
        /// <param name="value">The value of the element</param>
        /// <returns>Returns True if the element is found, and flase if not </returns>
        public bool Contains(T value)
        {
            foreach (var i in arr)
            {
                if (i.Equals(value))
                    return true;
            }
            return false;
        }

        // Enables the iteration through foreach
        public object Current
        {
            get { return arr[positon]; }
        }
        public bool MoveNext()
        {
            positon++;
            return (positon < Count);
        }

        public void Reset()
        {
            positon = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
