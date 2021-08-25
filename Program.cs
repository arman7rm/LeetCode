using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    class Program
    {

        static void Main(string[] args)
        {
            var blocks = new List<Dictionary<string, bool>>();
            
            var first = new Dictionary<string, bool>();
            first.Add("gym", false);
            first.Add("school", true);
            first.Add("store", false);
            blocks.Add(first);

            var second = new Dictionary<string, bool>();
            second.Add("gym", true);
            second.Add("school", false);
            second.Add("store", false);
            blocks.Add(second);

            var third = new Dictionary<string, bool>();
            third.Add("gym", true);
            third.Add("school", true);
            third.Add("store", false);
            blocks.Add(third);
            
            var fourth = new Dictionary<string, bool>();
            fourth.Add("gym", false);
            fourth.Add("school", true);
            fourth.Add("store", false);
            blocks.Add(fourth);

            var fifth = new Dictionary<string, bool>();
            fifth.Add("gym", false);
            fifth.Add("school", true);
            fifth.Add("store", true);
            blocks.Add(fifth);

            string[] reqs = {"gym","school","store" };
            ApartmentHunting(blocks, reqs);
        }
        public static int ApartmentHunting(List<Dictionary<string, bool>> blocks, string[] reqs)
        {
            // Write your code here.
            int minDist = Int32.MaxValue;
            int i = 0;
            int ans = -1;
            foreach (var block in blocks)
            {
                bool invalid = false;
                int totalDist = 0;

                foreach (var building in reqs)
                {
                    bool foundRight = false;
                    bool foundLeft = false;
                    int dist = 0;

                    for (int j = i; j < blocks.Count; j++)
                    {
                        if (blocks[j][building] == true)
                        {
                            foundRight = true;
                            break;
                        }
                        dist++;
                    }

                    if (!foundRight) dist = Int32.MaxValue;

                    int left = 0;
                    for (int j = i; j > -1; j--)
                    {
                        var curr = blocks[j];
                        if (curr[building])
                        {
                            foundLeft = true;
                            break;
                        }
                        left++;
                    }
                    if (!foundLeft) left = Int32.MaxValue;
                    if (!foundLeft && !foundRight)
                    {
                        invalid = true;
                        break;
                    }

                    dist = (int)Math.Min(dist, left);
                    totalDist += dist;
                }

                if (invalid)
                {
                    i++;
                    continue;
                }

                if (minDist >= totalDist)
                {
                    minDist = totalDist;
                    ans = i;
                }
                i++;
            }
            return ans;
        }
        public static int NumSplits(string s)
        {
            Dictionary<char, int> left = new Dictionary<char, int>();
            Dictionary<char, int> right = new Dictionary<char, int>();
            left.Add(s[0], 1);

            for (int i = 1; i < s.Length; i++)
            {
                if (!right.ContainsKey(s[i]))
                {
                    right.Add(s[i], 0);
                }
                right[s[i]]++;
            }
            int count = 0;
            for (int i = 1; i < s.Length - 1; i++)
            {
                right[s[i]]--;
                if (right[s[i]] == 0) right.Remove(s[i]);
                if (!left.ContainsKey(s[i]))
                {
                    left.Add(s[i], 0);
                }
                left[s[i]]++;
                if (left.Count == right.Count) count++;
            }
            return count;
        }
        public static int VisiblePoints(int[][] points, int angle, List<int> location) { 
        int maxPoints = 0;
        List<double> list = new List<double>();
        int seen = 0;
        foreach (int[] point in points){
            double opp = point[1] - location[1];
        double adj = point[0] - location[0];
            if (opp == 0 && adj == 0){
                seen++;
                continue;
            }
    double pointAngle = (Math.Atan2(opp, adj) * 180 / Math.PI);
            
            if(pointAngle<0){
                pointAngle += 360;
            }
list.Add(pointAngle);
        }
        list.Sort();
            int max = 0;
            foreach(int p in list)
            {
                int cap = p+angle;
                int count = 0;
                foreach(int x in list)
                {
                    if (x >= p && x <= cap) count++;

                }
                if (count > max) max = count;
            }
            return max + seen;/*
for (int d = 0; d < 360; d++)
{
    int visible = seen;

    double leftAngle = d + (angle / 2);
    double rightAngle = d - (angle / 2);
    //45 . -45,
    //350 = -10;
    foreach (int pointAngle in list)
    {
        if (rightAngle < 0 && pointAngle > 180)
        {
            rightAngle += 360;
            leftAngle += 360;
        }
        if (leftAngle >= pointAngle && rightAngle <= pointAngle) visible++;
    }


    if (visible > maxPoints) maxPoints = visible;
}

    return maxPoints;*/
    }

        public class master
        {
            string secret;
            public int guess(string word)
            {
                this.secret = "azzzzz";
                return numOfMatches(secret,word);
            }
        }
        public static void FindSecretWord(string[] wordlist, master master)
        {
            var list = new List<string>(wordlist);

            var guesses = 0;
            while (guesses < 10)
            {
                guesses++;
                var dict = new Dictionary<string, int>(); // key the word, value, # of zero matchese
                foreach (var word1 in list)
                {
                    foreach (var word2 in list)
                    {
                        if (countMatches(word1, word2) == 0)
                        {
                            if (dict.ContainsKey(word1))
                            {
                                dict[word1] += 1;
                            }
                            else
                            {
                                dict.Add(word1, 1);
                            }
                        }
                    }
                }
                var min = Int32.MaxValue;
                var guess = list[0];
                foreach (string word in dict.Keys)
                {
                    if (dict[word] < min)
                    {
                        guess = word;
                        min = dict[word];
                    }
                }
                var numOfLettersMatched = master.guess(guess);
                if (numOfLettersMatched == 6) return;
                var rem = new List<string>();
                foreach (var word in list)
                {
                    if (countMatches(guess, word) == numOfLettersMatched) rem.Add(word);
                }
                list = rem;
            }
        }

        public static int numOfMatches(string a, string b)
        {
            int matches = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i]) matches++;
            }

            return matches;
        }

        public static int minCostsFlights(List<int[]> costs)
        {
            int total = 0;
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            int user = 1;
            int i = 1;
            foreach(int[] flights in costs)
            {
                int diff = Math.Abs(flights[0]-flights[1]);
                if (map.ContainsKey(diff))
                {
                    map.Add(diff-i, user);
                    i++;
                }
                else
                {
                    map.Add(diff, user);
                }
                user++;
            }
            int cityA = 0, cityB = 0;
            foreach(var x in map.Reverse())
            {
                if(costs[x.Value-1][0]< costs[x.Value - 1][1])
                {
                    if(cityA < costs.Count / 2)
                    {
                        cityA++;
                        total += costs[x.Value - 1][0];
                    }
                    else
                    {
                        cityB++;
                        total += costs[x.Value - 1][1];
                    }
                }
                else
                {
                    if (cityB < costs.Count / 2)
                    {
                        cityB++;
                        total += costs[x.Value - 1][1];
                    }
                    else
                    {
                        cityA++;
                        total += costs[x.Value - 1][0];
                    }
                }
            }

            return total;
        }
        public class LRUCache
        {

            public int cap;
            public Dictionary<int, LinkedListNode<int>> map;
            public LinkedList<int> list;

            public LRUCache(int capacity)
            {
                this.cap = capacity;
                this.map = new Dictionary<int, LinkedListNode<int>>();
                this.list = new LinkedList<int>();
            }

            public int Get(int key)
            {
                if (map.ContainsKey(key))
                {
                    int val = map[key].Value;
                    list.Remove(map[key]);
                    list.AddLast(val);
                    map[key] = list.Last;
                    return map[key].Value;
                }
                return -1;
            }

            public void Put(int key, int value)
            {
                if (map.ContainsKey(key))
                {
                    list.Remove(map[key]);
                    list.AddLast(value);
                    map[key] = list.Last;
                }
                else
                {
                    if (map.Count == cap)
                    {
                        foreach (KeyValuePair<int, LinkedListNode<int>> kvp in map)
                        {
                            if (kvp.Value == list.First)
                            {
                                map.Remove(kvp.Key);
                                break;
                            }
                        }
                        list.RemoveFirst();
                    }
                    list.AddLast(value);
                    map.Add(key, list.Last);
                }
            }
        }
        public static List<int> TopologicalSort(List<int> jobs, List<int[]> deps)
        {
            // Write your code here.
            List<node> list = new List<node>();
            foreach (int job in jobs)
            {
                node n = new node(job);
                foreach (int[] pair in deps)
                {
                    if (pair[1] == n.val)
                    {
                        n.prereqs.Add(pair[0]);
                    }
                }
                list.Add(n);
            }
            List<int> ans = new List<int>();
            foreach (node n in list)
            {
                if (n.prereqs.Count == 0)
                {
                    ans.Add(n.val);
                    n.visited = true;
                }
            }
            if (ans.Count == 0)
            {
                return new List<int>();
            }
            while (ans.Count < list.Count)
            {
                foreach (node n in list)
                {
                    if (!n.visited)
                    {
                        bool valid = true;
                        foreach (int x in n.prereqs)
                        {
                            if (!ans.Contains(x)) valid = false;
                        }
                        if (valid)
                        {
                            ans.Add(n.val);
                            n.visited = true;
                        }
                    }
                }
            }
            return ans;
        }

        public class node
        {
            public bool visited;
            public int val;
            public List<int> prereqs;

            public node(int val)
            {
                this.visited = false;
                this.val = val;
                this.prereqs = new List<int>();
            }
        }
        public class Master
        {
            public string a = "azzzzz";
            public Master()
            {

            }
            public int Guess(string b)
            {
                int x = 0;
                for (int i = 0; i < this.a.Length; i++)
                {
                    if (this.a[i] == b[i]) x++;
                }
                return x;
            }
        }
        public static void FindSecretWord(string[] wordlist, Master master)
        {
            Array.Sort(wordlist);
            List<string> list = new List<string>(wordlist);

            int guesses = 0;
            while (guesses < 10 && list.Count > 0)
            {
                guesses++;
                var dict = new Dictionary<string, int>(); // key the word, value, # of zero matchese
                foreach (var word1 in list)
                {
                    foreach (var word2 in list)
                    {
                        if (countMatches(word1, word2) == 0)
                        {
                            if (dict.ContainsKey(word1))
                            {
                                dict[word1] += 1;
                            }
                            else
                            {
                                dict[word1] = 1;
                            }
                        }
                    }
                }
                int min = Int32.MaxValue;
                string guess = list[0];
                foreach (string word in dict.Keys)
                {
                    if (dict[word] < min)
                    {
                        guess = word;
                        min = dict[word];
                    }
                }
                int numOfLettersMatched = master.Guess(guess);
                List<string> rem = new List<string>();
                foreach (string word in list)
                {
                    if (countMatches(guess, word) != numOfLettersMatched) rem.Add(word);
                }
                foreach (string z in rem)
                {
                    list.Remove(z);
                }
            }
        }

        public static int countMatches(string a, string b)
        {
            int x = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i]) x++;
            }
            return x;

        }
        public static int Fib(int n, int[] mem)
        {
            if(n == 0)
            {
                return 1;
            }
            if(n == 1)
            {
                return 1;
            }
            if (mem[n] == 0)
            {
                mem[n] = mem[n-1] + mem[n-2];
            }
            return mem[n];
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

