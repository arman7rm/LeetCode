using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCode
{
    class Program {
        static void Main(string[] args)
        {
            ValidIPAddresses("1921680");
        }

        public int NonConstructibleChange(int[] coins)
        {
            // Write your code here.
            if (coins.Length == 0) return 1;
            int sum = 1;
            Array.Sort(coins);
            while (true)
            {
                int curr = sum;
                for (int i = 0; i < coins.Length; i++)
                {
                    if (sum < 0) return curr;
                    if (sum == 0)
                    {
                        sum = curr + 1;
                        break;
                    }
                    sum -= coins[i];
                }
            }
            return 1;
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
                if (row >= m.Length || col >= m.Length || row<0 || col< 0 || visited[row][col] == true)
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
