using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n = new Node(7);
            Node x = new Node(5);
            x.next = new Node(9);
            x.next.next = new Node(2);
            n.next = new Node(1);
            n.next.next = new Node(6);
            CTCILinkedList.sumLists(n, x);

        }
        public static string ShortenPath(string path)
        {
            // Write your code here;
            StringBuilder curr = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == '/' || i == path.Length - 1)
                {
                    if (i == path.Length - 1 || i == 0) curr.Append(path[i]);
                    string dir = curr.ToString();
                    if (dir.Length > 0) stack.Push(dir);
                    if (dir == "..")
                    {
                        if (stack.Count > 0) stack.Pop();
                        if (stack.Count > 0) stack.Pop();
                    }
                    else if (dir == ".")
                    {
                        if (stack.Count > 0) stack.Pop();
                    }
                    curr.Clear();
                }
                else
                {
                    curr.Append(path[i]);
                }
            }
            StringBuilder ans = new StringBuilder();
            List<string> list = new List<string>();
            foreach (string s in stack)
            {
                list.Add(s);
            }
            list.Reverse();
            for (int i = 0; i < list.Count; i++)
            {
                ans.Append(list[i]);
                if (i == 0 && list[i] == "/")
                {
                    continue;
                }
                if (i == list.Count - 1) continue;
                ans.Append("/");
            }
            return ans.ToString();
        }
        public static int[] NextGreaterElement(int[] array)
        {
            int[] ans = new int[array.Length];
            Array.Fill(ans, -1);
            for (int i = 0; i < array.Length; i++)
            {
                int curr = array[i];
                int x = 0;
                int j = i;
                while (x < array.Length - 1)
                {
                    if (j == array.Length) j = 0;
                    if (array[j] > curr)
                    {
                        ans[i] = array[j];
                        break;
                    }
                    x++;
                    j++;
                }
            }

            return ans;
        }

        public static int binarySearch(int[] arr, int l, int r, int target)
        {
            while (l < r)
            {
                int m = (l + r) / 2;
                if (target > arr[m])
                {
                    return binarySearch(arr, m + 1, r, target);
                }
                else if (target < arr[m])
                {
                    return binarySearch(arr, l, m - 1, target);
                }
                return m;
            }
            return 0;
        }
        public static void reverse(ref string s, int start, int end)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr, start, end - start);
            s = new string(arr);
        }
        public static List<int> SortStack(List<int> stack)
        {
            // Write your code here.
            List<int> list = new List<int>();
            for (int i = stack.Count - 1; i > -1; i--)
            {
                list.Add(stack[i]);
                stack.RemoveAt(i);
            }

            stack.Add(list[0]);
            list.RemoveAt(0);

            while (list.Count > 0)
            {
                int curr = list[0];
                List<int> mem = new List<int>();
                for (int i = stack.Count - 1; i > -1; i--)
                {
                    if (stack[i] < curr)
                    {
                        stack.Add(curr);
                        mem.Reverse();
                        foreach (int x in mem)
                        {
                            stack.Add(x);
                        }
                        break;
                    }
                    else
                    {

                        int pop = stack[stack.Count - 1];
                        stack.RemoveAt(stack.Count - 1);
                        mem.Add(pop);
                        if (i == 0)
                        {
                            stack.Add(curr);
                            mem.Reverse();
                            foreach (int x in mem)
                            {
                                stack.Add(x);
                            }
                            break;
                        }
                    }
                }
                list.RemoveAt(0);
            }
            return stack;
        }
        public static int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)
        {
            // your code goes here

            int a = 0, b = 0;

            while (a < slotsA.Length/2 && b < slotsB.Length)
            {
                int aST = slotsA[a, 0], aET = slotsA[a, 1];
                int bST = slotsB[b, 0], bET = slotsB[b, 1];

                if (aST < bET && bST < aET)
                {
                    int st = Math.Max(aST, bST);
                    int et = Math.Min(aET, bET);
                    if (et - st >= dur) return new int[] { st, st + dur };

                }
                if (aET < bET)
                {
                    a++;
                }
                else
                {
                    b++;
                }
            }
            return new int[] { };

        }
        public static char[] ReverseWords(char[] arr)
        {/*
      Array.Reverse(arr);
      int start=0;
      int i = 0;
      while(arr[i]!=' ' && i<arr.Length-1){
        i++;
        if(arr[i]==' ' || i==arr.Length-1){
          if(i==arr.Length-1){
            Array.Reverse(arr, start, arr.Length - start);
            return arr;
          }
          Array.Reverse(arr,start,i-start);
          while(' '==arr[i] && i<arr.Length){
            i++;
          }
          start = i;
        }
        
      }*/
            int i = 0, start = 0;
            List<string> list = new List<string>();
            while (i < arr.Length)
            {
                while (i < arr.Length && arr[i] != ' ')
                {
                    i++;
                }
                StringBuilder word = new StringBuilder();
                for (int j = start; j < i; j++)
                {
                    word.Append(arr[j]);
                }
                list.Add(word.ToString());
                start = i + 1;
                i++;
            }
            list.Reverse();
            int k = 0;
            foreach (string word in list)
            {
                foreach (char c in word)
                {
                    arr[k] = c;
                    k++;
                }
                if (k < arr.Length - 1)
                {
                    arr[k] = ' ';
                    k++;
                }
            }
            return arr;
        }
        public static int MinNumberOfCoinsForChange(int n, int[] denoms)
        {
            // Write your code here.
            Array.Sort(denoms);
            int sum = 0;
            for (int i = denoms.Length - 1; i >= 0; i--)
            {
                if (n == 0) return sum;
                while ((n - denoms[i]) >= 0)
                {
                    n -= denoms[i];
                    sum++;
                }
            }
            return -1;
        }
       
            public static List<string> ValidIPAddresses(string str)
            {
                // Write your code here.
                List<string> list = new List<string>();
                for (int i = 1; i < 4; i++)
                {
                    int si = 0;
                    string first = str.Substring(si, i);
                    if (!isValid(first)) continue;
                    for (int j = 1; j < 4; j++)
                    {
                        int ssi = i;
                        if (i + j >= str.Length) continue;
                        string second = str.Substring(ssi, j);
                        if (!isValid(second)) continue;
                        for (int k = 1; k < 4; k++)
                        {
                            int tsi = j + i;
                            if (tsi + k >= str.Length)
                            {
                                continue;
                            }
                            string third = str.Substring(tsi, k);
                            string fourth = str.Substring(j + k + i);
                            if (!isValid(third)) continue;
                            if (isValid(fourth))
                            {
                                StringBuilder ans = new StringBuilder();
                                ans.Append(first);
                                ans.Append(".");
                                ans.Append(second);
                                ans.Append(".");
                                ans.Append(third);
                                ans.Append(".");
                                ans.Append(fourth);
                                list.Add(ans.ToString());
                            }
                            if (list.Count == 7)
                            {
                                int z = 1;
                            }
                        }
                    }
                }
                return list;
            }

            public static bool isValid(string s)
            {
                if (s.Length == 0) return false;
                if (s.Length > 1)
                {
                    if (s[0] == '0' && s[1] == '0') return false;
                }
                int n = Int32.Parse(s);
                if (n > 255) return false;
                return true;
            }
            public class LinkedList
            {
                public int value;
                public LinkedList next;

                public LinkedList(int value)
                {
                    this.value = value;
                    this.next = null;
                }
            }

            public static LinkedList SumOfLinkedLists(LinkedList linkedListOne, LinkedList linkedListTwo)
            {
                // Write your code here.
                int a = LLtoNum(linkedListOne);
                int b = LLtoNum(linkedListTwo);
                return NumtoLL(a + b);
            }

            public static int LLtoNum(LinkedList ll)
            {
                int sum = 0;
                List<int> list = new List<int>();
                LinkedList runner = ll;
                while (runner != null)
                {
                    list.Add(runner.value);
                    runner = runner.next;
                }
                int pow = list.Count - 1;
                for (int i = 0; i < list.Count; i++)
                {
                    sum += (int)(list[i] * Math.Pow(10, pow));
                    pow--;
                }
                return sum;
            }

            public static LinkedList NumtoLL(int n)
            {
                List<int> list = new List<int>();
                while (n > 0)
                {
                    int temp = n % 10;
                    n = n / 10;
                    list.Add(temp);
                }
                list.Reverse();
                LinkedList ans = new LinkedList(list[0]);

                for (int i = 1; i < list.Count; i++)
                {
                    ans.next = new LinkedList(list[i]);
                    ans = ans.next;
                }
                return ans;
            }
            public static int[][] populateMatrix(int n)
            {
                List<int[]> dir = new List<int[]>();
                dir.Add(new int[] { 0, 1 });
                dir.Add(new int[] { 1, 0 });
                dir.Add(new int[] { 0, -1 });
                dir.Add(new int[] { -1, 0 });
                int[][] m = new int[n][];
                for (int i = 0; i < n; i++)
                {
                    m[i] = new int[n];
                }
                bool[][] visited = new bool[n][];
                for (int j = 0; j < n; j++)
                {
                    visited[j] = new bool[n];
                }
                int count = n * n;
                int row = 0, col = 0;
                int d = 0;
                while (count > 0)
                {
                    m[row][col] = count;
                    visited[row][col] = true;
                    row += dir[d][0];
                    col += dir[d][1];
                    if (row >= m.Length || col >= m.Length || row < 0 || col < 0 || visited[row][col] == true)
                    {
                        row -= dir[d][0];
                        col -= dir[d][1];
                        d++;
                        if (d > 3)
                        {
                            d = 0;
                        }
                        row += dir[d][0];
                        col += dir[d][1];
                    }
                    count--;
                }
                return m;
            }
    }
    
}

