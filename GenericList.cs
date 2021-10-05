using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_List
{
    /// <summary>
    /// Generic Class that represents C# List<T> 
    /// </summary>
    /// <typeparam name="T"> A generic value</typeparam>
    class GenericList<T> where T : new()
    {
        // The basic Array to hold the elements
        T[] arr;

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
            Array.Resize(ref arr, Capacity * 2);
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
                if (index > Count || index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index Out Of Range");

                return arr[index];   
            }
        }

        /// <summary>
        /// Remove the element that has the specified value
        /// </summary>
        /// <param name="value">the element value</param>
        public void Remove(T value)
        {
            try
            {
                arr = arr.Where((arr) => !arr.Equals(value)).ToArray();
                Count--;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }   
        }

        /// <summary>
        /// Remove the element at the specified index
        /// </summary>
        /// <param name="index">the index of the element</param>
        public void RemoveAt(int index)
        {
            if (index > Count || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index Out Of Rnage");

            arr = arr.Where((arr, val) => val != index).ToArray();
            Count--;  
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
            foreach(var i in arr)
            {
                if (i.Equals(value))
                    return true;
            }
            return false;
        }
    }
}
