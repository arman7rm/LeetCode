using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Node
    {
        public object data;
        public Node next;

        public Node(char x)
        {
            data = x;
            next = null;
        }
        public Node(int x)
        {
            data = x;
            next = null;
        }

    }

    class LinkedList
    {
        public Node head;
       
        int count;
        public Node tail;
        public int length
        {
            get
            {
                return count;
            }
        }

        public LinkedList()
        {
            head = null;
            tail = head;
            count = 0;
        }
        public void AddFrontNode(int data)
        {
            Node newNode = new Node(data);
            newNode.next = head;
            head = newNode;
            count++;
        }
        public void AddBackNode(int data)
        {
            Node newNode = new Node(data);
            Node runner = head;
            while (runner.next != null)
            {

                runner = runner.next;
            }
            runner.next = newNode;
            tail = newNode;
            count++;
        }
        public void printNodes()
        {
            Node runner = head;
            while (runner != null)
            {
                Console.WriteLine(runner.data);
                runner = runner.next;
            }
        }
    }
}
