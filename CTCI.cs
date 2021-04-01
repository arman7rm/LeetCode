using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class CTCI
    {
        public static bool isUnique(string s)
        {
            for(int i=0; i<s.Length-1; i++)
            {
                for(int j=i+1; j<s.Length; j++)
                {
                    if (s[j] == s[i]) return false;
                }
            }
            return true;
        }

        public static bool isUnique2(string s)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < s.Length ; i++)
            {
                if (list.Contains(s[i])) return false;
                list.Add(s[i]);
            }
            return true;
        }

        public static bool checkPermutation(string a, string b)
        {
            if (a.Length != b.Length) return false;
            List<char> list = new List<char>();
            foreach(char x in a)
            {
                list.Add(x);
            }
            foreach(char y in b)
            {
                if (list.Contains(y))
                {
                    list.Remove(y);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool checkPermutation2(string a, string b)
        {
            if (a.Length != b.Length) return false;
            a = sort(a);
            b = sort(b);
            return a.Equals(b);
        }
        public static string sort(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort(content);
            StringBuilder ans = new StringBuilder();
            foreach(char c in content)
            {
                ans.Append(c);
            }
            return ans.ToString();
        }
    }
}
