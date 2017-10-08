using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    interface ILinkedListNode<T>
    {
        T Value { get; set; }
        ILinkedListNode<T> Next { get; set; }
        bool HasNext { get; }
        bool IsEqual(T value);
    }

    public interface ILinkedList<T> : IEnumerable<T>
    {
        void Insert(T item);
        void Delete(T item);
    }

    class SinglyLinkedListNode<T> : ILinkedListNode<T>
    {
        public SinglyLinkedListNode(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value { get; set; }
        public ILinkedListNode<T> Next { get; set; }

        public bool HasNext { get { return this.Next != null; } }

        public bool IsEqual(T value)
        {
            return EqualityComparer<T>.Default.Equals(this.Value, value);
        }
    }

    public class SinglyLinkedList<T> : ILinkedList<T>
    {
        private ILinkedListNode<T> startNode;
        private ILinkedListNode<T> lastNode;

        public SinglyLinkedList()
        {
            this.startNode = null;
            this.lastNode = null;
        }

        public void Insert(T value)
        {
            var node = new SinglyLinkedListNode<T>(value);

            if (this.startNode == null)
                this.startNode = node;

            if (this.lastNode == null)
                this.lastNode = node;
            else
            {
                this.lastNode.Next = node;
                this.lastNode = node;
            }
        }

        public void Delete(T value)
        {
            if (this.startNode == null)
                throw new InvalidOperationException("Cannot call delete on an empty list");
            else if (this.startNode.IsEqual(value))
            {
                if (this.startNode == this.lastNode)
                    this.lastNode = null;

                this.startNode = this.startNode.Next;
            }
            else
            {
                var node = this.startNode;
                while (node.HasNext)
                {
                    if (node.Next.IsEqual(value))
                    {
                        if (this.lastNode == node.Next)
                            this.lastNode = node;

                        node.Next = node.Next.Next;

                        return;
                    }

                    node = node.Next;
                }

                throw new InvalidOperationException("No element found to delete with value " + value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.startNode;
            if (node != null)
                yield return node.Value;

            while (node != null && node.HasNext)
            {
                node = node.Next;
                yield return node.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
