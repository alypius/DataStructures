using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace AlgorithmsTest.DataStructures
{
    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void PriorityQueueBasic()
        {
            var priorityQueue = new PriorityQueue<int>();

            Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Peek());
            Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());

            Assert.AreEqual(0, priorityQueue.Count);

            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(4);

            Assert.AreEqual(5, priorityQueue.Count);

            Assert.AreEqual(1, priorityQueue.Peek());

            Assert.AreEqual(1, priorityQueue.Dequeue());
            Assert.AreEqual(2, priorityQueue.Dequeue());
            Assert.AreEqual(3, priorityQueue.Dequeue());
            Assert.AreEqual(4, priorityQueue.Dequeue());
            Assert.AreEqual(5, priorityQueue.Dequeue());

            Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Peek());
            Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());

            Assert.AreEqual(0, priorityQueue.Count);
        }
    }
}
