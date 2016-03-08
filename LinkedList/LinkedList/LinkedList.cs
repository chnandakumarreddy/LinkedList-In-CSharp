using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// This is Stack implementation using Linked List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IStack<T>
    {
        private class Node
        {
            public T data { get; set; }
            public Node next { get; set; }

            public Node(T nodeData)
            {
                data = nodeData;
                next = null;
            }
        }

        public int Count { get; private set; }
        private Node headNode;
        private Node currentNode;

        //Constructor that intializes the stack count to zero
        public LinkedList()
        {
            Count = 0;
            headNode = currentNode = null;
        }

        public void Push(T newData)
        {
            Node newNode = new Node(newData);
            newNode.next = null;

            //If current node is null it means there are no items in the linked list
            if (currentNode == null)
            {
                headNode = newNode;
            }
            else
            {
            //update the last node next reference as new node
                currentNode.next = newNode;
            }

            //update the newNode as the latest node
            currentNode = newNode;
            this.Count++; //Increment the stack count
        }

        public T Pop()
        {
            if (headNode == null)   // No elements in the stack
                throw new InvalidOperationException("Stack is empty");

            Node deletedNode = null;
            Node tempNode = headNode;
            while (tempNode != null)
            {
                if (tempNode.next == currentNode)   // means next iteration is last node
                {
                    deletedNode = tempNode.next; //store the last node before deletion
                    tempNode.next = null; // this makes the last node as orphan and also breaks the while condition
                    currentNode = tempNode; //set the current node as this node
                    this.Count--; // decremetn the stack count
                }
                tempNode = tempNode.next;
            }
            return deletedNode.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node tempNode = headNode;
            while (tempNode != null)
            {
                yield return tempNode.data;
                tempNode = tempNode.next;
            }
        }

    }


}
