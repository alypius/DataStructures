using System;
using System.Collections.Generic;
using System.Linq;
using BinarySearch = Algorithms.Searching.BinarySearch;

namespace Algorithms.DataStructures
{

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> queue = new List<T>();

        public int Count { get { return this.queue.Count; } }

        public void Enqueue(T item)
        {
            this.queue.Insert(BinarySearch.FindClosestIndex(this.queue, item), item);
        }

        public T Dequeue()
        {
            if (this.Count == 0)
                throw new InvalidOperationException("Cannot call dequeue on an empty queue");

            var item = this.queue.First();
            this.queue.Remove(item);
            return item;
        }

        public T Peek()
        {
            if (this.Count == 0)
                throw new InvalidOperationException("Cannot call peek on an empty queue");

            return this.queue.First();
        }
    }
}
