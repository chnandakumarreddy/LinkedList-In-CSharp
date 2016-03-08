using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System.Collections.Generic;

namespace DataStructures.LinkedListTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void CanAddSingleNodeToLinkedList()
        {
            var list = new DataStructures.LinkedList<int>();
            list.Push(10);
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void CanAddMultipleNodesToLinkedList()
        {
            var list = new DataStructures.LinkedList<int>();
            list.Push(10);
            list.Push(20);
            list.Push(30);
            list.Push(40);
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void CanRemoveNodeFromLinkedList()
        {
            var list = new DataStructures.LinkedList<int>();
            list.Push(10);
            list.Push(20);
            list.Push(30);
            var deletedItem = list.Pop();
            Assert.IsTrue(deletedItem == 30 && list.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanRemoveNodeFromEmptyLinkedList()
        {
            var list = new DataStructures.LinkedList<int>();
            var deletedItem = list.Pop();
        }

        [TestMethod]
        public void CanGetNodesFromLinkedList()
        {
            List<int> stackInput = new List<int>() { 10, 20, 30, 40, 50};
            var list = new DataStructures.LinkedList<int>();
            foreach (var integerItem in stackInput)
            {
                list.Push(integerItem);
            }
            List<int> stackOutput = new List<int>();
            foreach (var listItem in list)
            {
                stackOutput.Add(listItem);
            }

            CollectionAssert.AreEqual(stackInput, stackOutput);
        }

    }
}
