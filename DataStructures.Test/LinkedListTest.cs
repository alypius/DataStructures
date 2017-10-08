using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace AlgorithmsTest.DataStructures
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void LinkedListBasic()
        {
            var linkedList = new SinglyLinkedList<int>();
            Assert.AreEqual(0, linkedList.Count());

            Assert.ThrowsException<InvalidOperationException>(() => linkedList.Delete(0));

            linkedList.Insert(0);
            Assert.AreEqual(1, linkedList.Count());
            CollectionAssert.AreEqual(new int[] { 0 }, linkedList.ToArray());
            CollectionAssert.AreEqual(new int[] { 1 }, linkedList.Select(it => it + 1).ToArray());

            Assert.ThrowsException<InvalidOperationException>(() => linkedList.Delete(1));
            linkedList.Delete(0);
            Assert.AreEqual(0, linkedList.Count());

            Assert.ThrowsException<InvalidOperationException>(() => linkedList.Delete(0));

            linkedList.Insert(0);
            CollectionAssert.AreEqual(new int[] { 0 }, linkedList.ToArray());
        }

        [TestMethod]
        public void LinkedListRemoveFromStart()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Insert(1);
            linkedList.Insert(2);
            linkedList.Insert(3);

            Assert.AreEqual(linkedList.Count(), 3);

            linkedList.Delete(1);

            Assert.AreEqual(linkedList.Count(), 2);
            CollectionAssert.AreEqual(new int[] { 2, 3 }, linkedList.ToArray());

            linkedList.Insert(1);

            Assert.AreEqual(linkedList.Count(), 3);
            CollectionAssert.AreEqual(new int[] { 2, 3, 1 }, linkedList.ToArray());
        }

        [TestMethod]
        public void LinkedListRemoveFromMiddle()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Insert(1);
            linkedList.Insert(2);
            linkedList.Insert(3);

            Assert.AreEqual(linkedList.Count(), 3);

            linkedList.Delete(2);

            Assert.AreEqual(linkedList.Count(), 2);
            CollectionAssert.AreEqual(new int[] { 1, 3 }, linkedList.ToArray());

            linkedList.Insert(2);

            Assert.AreEqual(linkedList.Count(), 3);
            CollectionAssert.AreEqual(new int[] { 1, 3, 2 }, linkedList.ToArray());
        }

        [TestMethod]
        public void LinkedListRemoveFromEnd()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Insert(1);
            linkedList.Insert(2);
            linkedList.Insert(3);

            Assert.AreEqual(linkedList.Count(), 3);

            linkedList.Delete(3);

            Assert.AreEqual(linkedList.Count(), 2);
            CollectionAssert.AreEqual(new int[] { 1, 2 }, linkedList.ToArray());

            linkedList.Insert(3);

            Assert.AreEqual(linkedList.Count(), 3);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, linkedList.ToArray());
        }
    }
}
