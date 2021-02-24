using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class past
    {
        public static bool isValid(TreeNode root)
        {
            List<int> list = new List<int>();
            helper(list, root);
            return isSorted(list);
        }

        private static bool isSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
        public static void LargestRange()
        {
            // Write your code here.
            int[] array = { 1, 11, 3, 0, 15, 5, 2, 4, 10, 7, 12, 6 };
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int x in array)
            {
                if (!map.ContainsKey(x))
                {
                    map.Add(x, 1);
                }
            }
            int max = Int32.MinValue;
            int[] ans = new int[2];
            for (int i = 0; i < array.Length; i++)
            {
                int curr = array[i];
                int range = 1, next = curr + 1;
                while (map.ContainsKey(next))
                {
                    range++;
                    next++;
                }
                if (range >= max)
                {
                    max = range;
                    ans[0] = curr;
                    ans[1] = curr + range - 1;
                }
            }
        }
        public static void helper(List<int> list, TreeNode root)
        {
            if (root != null)
            {
                helper(list, root.left);
                list.Add(root.val);
                helper(list, root.right);
            }
        }

        /*      public static bool helper(TreeNode root, int? min, int? max)
              {
                  if (root == null) return true;
                  if (min != null && root.val <= min) return false;
                  if (max != null && root.val > max) return false;
                  return helper(root.left, min, root.val) && helper(root.right, root.val, max); 
              }*/
        public static bool HasSingleCycle(int[] array)
        {
            // Write your code here.
            List<int> list = new List<int>();
            for (int j = 0; j < array.Length; j++)
            {
                list.Add(j);
            }
            int i = nextIndex(array, 0);
            while (list.Count != 0)
            {
                if (!list.Contains(i)) break;
                list.Remove(i);
                i = nextIndex(array, i);
            }
            return list.Count == 0;
        }

        public static int nextIndex(int[] arr, int curr)
        {
            int n = arr.Length, m = arr[curr];
            int newIndex = m + curr;
            if (newIndex >= n)
            {
                newIndex = newIndex % n;
            }
            else if (newIndex < 0)
            {
                n = n * -1;
                if (newIndex < n)
                {
                    newIndex = newIndex % arr.Length;
                    newIndex += arr.Length;
                }
                else
                {
                    newIndex += arr.Length;
                }
            }
            return newIndex;
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public static IList<int> RightSideView(TreeNode root)
        {
            List<int> ans = new List<int>();
            ans = bfs(root, ans);
            return ans;

        }
        public static List<int> bfs(TreeNode root, List<int> ans)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode temp = q.Dequeue();
                ans.Add(temp.val);
                if (root.left != null)
                {
                    q.Enqueue(root.left);
                }
                if (root.right != null)
                {
                    q.Enqueue(root.right);
                }
            }
            return ans;
        }
        //public static IList<int> RightSideView(TreeNode root)
        //{
        //    List<int> ans = new List<int>();
        //    List<int> result = Helper(root, ans);
        //    int l = result.Count - 1;
        //    if (root.left == null) return result;
        //    root = root.left;
        //    List<int> leftside = new List<int>();
        //    leftside = Helper(root, leftside);
        //    result.AddRange(Helper(root, result).GetRange(ans.Count, leftside.Count-ans.Count));
        //    return result;
        //}

        //public static List<int> Helper(TreeNode root, List<int> ans)
        //{
        //    if (root != null)
        //    {
        //        ans.Add(root.val);
        //        Helper(root.right, ans);
        //        if (root.right == null && root.left == null) return ans;
        //        if (root.right != null) return ans;
        //        Helper(root.left, ans);
        //    }
        //    return ans;
        //}
        public static void Coin(int[] coins, int amount)
        {
            Array.Sort(coins);
            int count = 0;
            for (int i = coins.Length - 1; i > -1; i--)
            {
                count += (amount / coins[i]);
                amount = amount % coins[i];
            }
            int ans = amount == 0 ? count : -1;
            Console.WriteLine(ans);
        }
        public static string SmallestGoodBase(string n)
        {
            double k = 2;
            double N = double.Parse(n);
            while (k < N)
            {
                double ans = (N * k) - N + 1;
                double exp = Math.Log(ans, k);
                if (exp % 1 == 0)
                {
                    if (k == N - 1) return n;
                    return k.ToString();
                }
                k++;
            }
            return n;


        }
        public static int BaseSummation(int k, int j)
        {
            return ((int)Math.Pow(k, j - 1) - 1) / (k - 1);
        }
        public class Animal
        {
            public string Name;
            public string Type;
            public Animal(string name, string type)
            {
                this.Name = name;
                this.Type = type;
            }
        }
        public class AnimalShelter
        {
            LinkedList<Animal> animals = new LinkedList<Animal>();
            LinkedList<Animal> dogs = new LinkedList<Animal>();
            LinkedList<Animal> cats = new LinkedList<Animal>();

            public AnimalShelter()
            {

            }
            public void Enqueue(Animal animal)
            {
                Animal temp = animal;
                animals.AddLast(temp);
                if (temp.Type.Equals("dog"))
                {
                    dogs.AddLast(temp);
                }
                else
                {
                    cats.AddLast(temp);
                }
            }
            public string Dequeue()
            {
                LinkedListNode<Animal> temp = animals.First;
                animals.RemoveFirst();
                if (temp.Value.Type.Equals("dog"))
                {
                    dogs.RemoveFirst();
                    return temp.Value.Name;
                }
                else
                {
                    cats.RemoveFirst();
                    return temp.Value.Name;
                }
            }
            public string DequeueCat()
            {
                LinkedListNode<Animal> temp = cats.First;
                cats.RemoveFirst();
                LinkedListNode<Animal> runner = animals.First;
                while (runner.Value.Type != "cat")
                {
                    runner = runner.Next;
                }
                animals.Remove(runner);
                return temp.Value.Name;

            }
            public string DequeueDog()
            {
                LinkedListNode<Animal> temp = dogs.First;
                dogs.RemoveFirst();
                LinkedListNode<Animal> runner = animals.First;
                while (runner.Value.Type != "dog")
                {
                    runner = runner.Next;
                }
                animals.Remove(runner);
                return temp.Value.Name;
            }
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public static void TrapRain(int[] n)
        {

        }

        public static char[] ReverseWords(char[] arr)
        {
            Array.Reverse(arr);
            int start = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == ' ' || i == arr.Length - 1)
                {
                    Array.Reverse(arr, start, i + 1 - start);
                    start = i + 1;
                }
            }
            return arr;
        }

        public static bool isSub(string s, string a)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (a[i] != s[i]) return false;
            }
            return true;
        }
        public static void zero_matrix(int[][] matrix)
        {
            Dictionary<int, int> map1 = new Dictionary<int, int>();
            Dictionary<int, int> map2 = new Dictionary<int, int>();
            int m = matrix.Length;
            int n = matrix[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (map1.ContainsKey(i))
                        {
                            continue;
                        }
                        if (map2.ContainsKey(j))
                        {
                            continue;
                        }
                        map1.Add(i, 1);
                        map2.Add(j, 1);
                        for (int k = 0; k < n; k++)
                        {
                            matrix[i][k] = 0;
                        }
                        for (int k = 0; k < m; k++)
                        {
                            matrix[k][j] = 0;
                        }
                        break;
                    }
                }
            }
        }


        public static void testSinglyLinkedList()
        {
            LinkedList list = new LinkedList();
            list.AddFrontNode(1);
            list.AddFrontNode(2);
            list.AddFrontNode(3);
            list.AddBackNode(5);
            list.AddBackNode(5);
            list.AddBackNode(6);
            list.printNodes();
            Console.WriteLine("Head is " + list.head.data);
            Console.WriteLine("Tail is " + list.tail.data);
            Console.WriteLine("length is " + list.length);
        }

        public static bool isPalindromePerm(string s)
        {
            s.ToLower();
            StringBuilder str = new StringBuilder(s);
            str.Replace(" ", "");
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                if (map.ContainsKey(str[i]))
                {
                    map[str[i]]++;
                }
                else
                {
                    map.Add(str[i], 1);
                }
            }

            bool single = false;
            foreach (KeyValuePair<char, int> kvp in map)
            {
                if (kvp.Value % 2 == 0)
                {
                    continue;
                }
                else
                {
                    if (single)
                    {
                        return false;
                    }
                    single = true;
                }
            }
            return true;
        }

        public static bool oneAway(string s, string a)
        {

            if (a.Length == s.Length)
            {
                bool replaced = false;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != a[i] && replaced == false)
                    {
                        replaced = true;
                        s = s.Replace(s[i], a[i]);
                        return a.Equals(s);
                    }

                }
                return a.Equals(s);
            }
            if (s.Length > a.Length)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (j == s.Length - 1)
                    {
                        s = s.Remove(j, 1);
                        return s.Equals(a);
                    }
                    if (s[j] != a[j])
                    {
                        s = s.Remove(j, 1);
                        return s.Equals(a);

                    }
                }
            }
            else
            {
                for (int k = 0; k < a.Length; k++)
                {
                    if (k == a.Length - 1)
                    {
                        a = a.Remove(k, 1);
                        return s.Equals(a);
                    }
                    if (s[k] != a[k])
                    {
                        a = a.Remove(k, 1);
                        return s.Equals(a);

                    }
                }
            }
            return true;
        }

        public static string stringCompression(string s)
        {
            //aaabbcccc : a3b2c4
            //special case 1
            if (s.Length < 1) return s;
            if (s.Length == 1)
            {
                string x = s;
                x += '1';
                return x;
            }
            char curr = s[0];
            int counter = 0;
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (i == s.Length - 1)
                {
                    if (s[i] == curr)
                    {
                        ans.Append(curr);
                        counter++;
                        ans.Append(counter);
                        return ans.ToString();
                    }
                    else
                    {
                        ans.Append(curr);
                        ans.Append(counter);
                        ans.Append(s[i]);
                        ans.Append(1);
                        return ans.ToString();
                    }
                }
                if (s[i] == curr)
                {
                    counter++;
                }
                else
                {
                    //aaabb
                    ans.Append(curr);
                    ans.Append(counter);
                    curr = s[i];
                    counter = 1;
                }
            }
            return ans.ToString();
        }

    }
    public class que
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        public int count;

        public que()
        {
            count = 0;
        }
        public que(int n)
        {
            stack2.Push(n);
            count = stack2.Count;
        }

        public void push(int n)
        {
            if (stack1.Count == 0)
            {
                if (stack2.Count == 0)
                {
                    stack2.Push(n);
                    count = stack2.Count;
                    return;
                }
                while (stack2.Count != 0)
                {
                    stack1.Push(stack2.Pop());
                }
                stack1.Push(n);

                while (stack1.Count != 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            count = stack2.Count;
        }

        public int? pop()
        {
            if (stack2.Count != 0)
            {
                int j = stack2.Pop();
                count = stack2.Count;
                return j;
            }
            return null;
        }
    }

    class SortedStack
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        public SortedStack()
        {

        }
        public SortedStack(int n)
        {
            stack1.Push(n);
        }
        public void Push(int n)
        {
            if (stack1.Count == 0)
            {
                stack1.Push(n);
                return;
            }
            else if (stack1.Peek() >= n)
            {
                stack1.Push(n);
            }
            else
            {
                while (stack1.Count > 0 && stack1.Peek() < n)
                {
                    stack2.Push(stack1.Pop());
                }
                stack1.Push(n);
                while (stack2.Count != 0)
                {
                    stack1.Push(stack2.Pop());
                }
            }

        }
        public int? Pop()
        {
            if (isEmpty() == true)
            {
                return null;
            }
            return stack1.Pop();
        }
        public int? Peek()
        {
            if (isEmpty()) return null;
            return stack1.Peek();
        }
        public bool isEmpty()
        {
            return stack1.Count == 0;
        }

    }
}

