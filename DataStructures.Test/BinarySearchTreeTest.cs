using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace AlgorithmsTest.DataStructures
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        private int[] GetAllNums(BinarySearchTree<int> tree)
        {
            var list = new List<int>();
            tree.Traverse(it => list.Add(it));
            return list.ToArray();
        }

        private void Test(BinarySearchTree<int> tree, int expectedLength)
        {
            var nums = GetAllNums(tree);

            Assert.AreEqual(expectedLength, nums.Length);

            foreach (var num in nums)
                Assert.AreEqual(num, tree.Find(num).Value);

            if (nums.Length > 0)
            {
                Assert.AreEqual(nums.Min(), tree.Minimum().Value);
                Assert.AreEqual(null, tree.Find(nums.Min() - 1));
                Assert.AreEqual(null, tree.Find(nums.Max() + 1));
            }
            else
            {
                Assert.AreEqual(null, tree.Minimum());
                Assert.AreEqual(null, tree.Find(0));
            }
        }

        private void InsertTest(BinarySearchTree<int> tree, int num)
        {
            var len = GetAllNums(tree).Length;
            tree.Insert(num);
            Test(tree, len + 1);
        }

        private void DeleteTest(BinarySearchTree<int> tree, int num)
        {
            var len = GetAllNums(tree).Length;
            tree.Delete(num);
            Test(tree, len - 1);
        }

        [TestMethod]
        public void BinarySearchTreeBasic()
        {
            var tree = new BinarySearchTree<int>();
            Test(tree, 0);

            InsertTest(tree, 2);
            InsertTest(tree, 1);
            InsertTest(tree, 3);
            InsertTest(tree, 0);
            InsertTest(tree, 5);

            DeleteTest(tree, 1);
            DeleteTest(tree, 3);
            DeleteTest(tree, 0);
            DeleteTest(tree, 5);

            InsertTest(tree, 1);
            InsertTest(tree, 3);

            DeleteTest(tree, 2);
            DeleteTest(tree, 1);
            DeleteTest(tree, 3);

            Test(tree, 0);
            InsertTest(tree, 4);
        }
    }
}
