using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class arrays
    {
        public static bool isUnique(string s)
        {
            HashSet<char> list = new HashSet<char>();
            for(int i=0; i<s.Length; i++)
            {
                if (list.Contains(s[i])) return false;
                list.Add(s[i]);
            }
            return true;
        }

        public static bool checkPermutation(string a, string b)
        {
            var map = new Dictionary<char, int>();
            foreach(var c in a)
            {
                if (!map.ContainsKey(c)) map.Add(c,0);
                map[c]++;
            }
            foreach(var c in b)
            {
                if (!map.ContainsKey(c)) return false;
                map[c]--;
            }
            foreach(var kvp in map)
            {
                if (kvp.Value != 0) return false;
            }
            return true;
        }

        public static string URLify(char[] s)
        {
            var temp = new StringBuilder();
            foreach(var c in s)
            {
                if(c==' ')
                {
                    temp.Append("%20");
                }
                else
                {
                    temp.Append(c);
                }
            }
            return temp.ToString();
        }

        public static bool palindromePermutation(string s)
        {
            bool odd = false;
            var map = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if (c == ' ') continue;
                if (!map.ContainsKey(c)) map.Add(c, 0);
                map[c]++;
            }
            foreach(var kvp in map)
            {
                if (kvp.Value % 2 == 1)
                {
                    if (odd)
                    {
                        return false;
                    }
                    odd = true;
                }
            }
            return true;
        }

        public static bool oneAway(string a , string b)
        {
            if (Math.Abs(a.Length - b.Length)> 1) return false;
            var map1 = new Dictionary<char, int>();
            var map2 = new Dictionary<char, int>();
            foreach (char c in a)
            {
                if(!map1.ContainsKey(c)) map1.Add(c,0);
                map1[c]++;
            }
            foreach (char c in b)
            {
                if (!map2.ContainsKey(c)) map2.Add(c, 0);
                map2[c]++;
            }

                bool exception = true;
                foreach(var kvp in map1)
                {
                    if (!map2.ContainsKey(kvp.Key) || map2[kvp.Key]!=kvp.Value)
                    {
                        if (!exception) return false;
                        exception = false;
                    }
                }
                return true;
            
        }

        public static string stringCompression(string s)
        {
            if (s.Length < 3) return s;

            StringBuilder ans = new StringBuilder();
            ans.Append(s[0]);
            char curr = s[0];
            int count = 1;
            for(int i=1; i<s.Length; i++)
            {
                if (s[i] != curr)
                {
                    ans.Append(count);
                    ans.Append(s[i]);
                    curr = s[i];
                    count = 1;
                }
                else
                {
                    count++;
                }
            }
            ans.Append(count);
            return ans.ToString().Length<s.Length? ans.ToString() : s;
        }

        public static void rotateMatrix(char[,] matrix)
        {
            var ans = new char[3, 3];
            for(int i=0; i<3; i++)
            {
                for(int j = 0; j<3; j++)
                {
                    ans[i,j] = matrix[j,i];
                }
            }
            for(int i=0; i<3; i++)
            {
                for(int j = 0; j<3/2; j++)
                {
                    char temp = ans[i, j];
                    ans[i, j] = ans[i, 3 - 1 - j];
                    ans[i,3- 1 - j] = temp;
                }
            }
            for (int i = 0; i <3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    Console.Write(ans[i,j]);
                }
                Console.WriteLine(" ");
            }
        }


    }
}
