using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class CTCILinkedList
    {
        public static void removeDuplicates(Node n)
        {
            Node runner = n;
            List<int> list = new List<int>();
            while (runner.next != null)
            {
                list.Add((int)runner.data);
                if (list.Contains((int)runner.next.data))
                {
                    runner.next = runner.next.next;
                }
                else
                {
                    runner = runner.next;
                }
            }
            while (n != null)
            {
                Console.WriteLine(n.data);
                n = n.next;
            }
        }

        public static Node kthToLast(Node n, int k)
        {
            int count = 0;
            Node runner = n;
            while(runner != null)
            {
                count++;
                runner = runner.next;
            }
            int j = 0;
            Node ans = n;
            while(j < (count - k))
            {
                j++;
                ans = ans.next;
            }
            return ans;
        }

        public static void deleteMiddleNode(Node n)
        {
            n.data = n.next.data;
            n.next = n.next.next;
        }

        public static void partition(Node n, int x)
        {
            Node left = new Node(0);
            Node head = left;
            Node right = new Node(0);
            Node rHead = right;

            while(n != null)
            {
                if((int)n.data < x)
                {
                    left.next = new Node((int)n.data);
                    left = left.next;
                }
                else
                {
                    right.next = new Node((int)n.data);
                    right = right.next;
                }
                n = n.next;
            }
            left.next = rHead.next;
            while(head.next != null)
            {
                Console.WriteLine(head.next.data);
                head = head.next;
            }
        }

        public static void sumLists(Node a, Node b)
        {
            int sumA = 0, sumB = 0, p = 0;
            while(a != null)
            {
                sumA += (int)Math.Pow(10, p) * (int)a.data;
                a = a.next;
                p++;
            }
            p = 0;
            while(b != null)
            {
                sumB += (int)Math.Pow(10, p) * (int)b.data;
                b = b.next;
                p++;
            }
            int sum = sumA + sumB;
            Node ans = new Node(sum%10);
            sum /= 10;
            while(sum > 0)
            {
                Console.Write(ans.data);
                ans.next = new Node(sum%10);
                sum /= 10;
                ans = ans.next;
            }
            Console.Write(ans.data);
        }

        public static bool palindromeLinkedList(Node n)
        {
            StringBuilder s = new StringBuilder();
            while(n != null)
            {
                s.Append(n.data);
                n = n.next;
            }
            string word = s.ToString();
            for(int i = 0; i < word.Length/2; i++)
            {
                if (word[i] != word[word.Length - i - 1]) return false;
            }
            return true;
        }

        public static Node? intersection(Node a, Node b)
        {
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();
            while (a != null)
            {
                s1.Push(a);
                a = a.next;
            }
            while (b != null)
            {
                s2.Push(b);
                b = b.next;
            }
            Node prev = null;
            while(s1.Count > 0 && s2.Count > 0)
            {
                if (s1.Peek() != s2.Peek()) return prev;
                prev = s1.Pop();
                s2.Pop();
            }
            return null;
        }

        public static Node circularLinkedList(Node n)
        {
            List<Node> list = new List<Node>();
            while (!list.Contains(n))
            {
                list.Add(n);
                n = n.next;
            }
            return n;
        }
    }
}
