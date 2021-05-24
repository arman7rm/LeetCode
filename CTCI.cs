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

        //Write a method that replaces all spaces in a string with '%20'
        public static string URLify(string a, int n)
        {
            char[] s = a.ToCharArray();
            int spaces = 0;
            for(int i=0; i<n; i++)
            {
                if (s[i] == ' ') spaces++;
            }
            int index = n + spaces * 2;
            for(int j=n-1; j>=0; j--)
            {
                if(s[j]==' ')
                {
                    s[index - 1] = '0';
                    s[index - 2] = '2';
                    s[index - 3] = '%';
                    index -= 3;
                }
                else
                {
                    s[index - 1] = s[j];
                    index--;
                }
            }
            return new string(s);

        }

        public static bool palindromePermutation(string c)
        {
            if (c.Length <= 1) return true;
            if (c.Length == 2) return c[0] == c[1];
            char[] s = c.ToCharArray();
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char x in s)
            {
                if (!map.ContainsKey(x)) map.Add(x, 0);
                map[x]++;
            }
            if (map.ContainsKey(' ')) map.Remove(' ');
            if (map.Count == 1) return true;
            int odd = 0;
            foreach (KeyValuePair<char, int> kvp in map)
            {
                if (kvp.Value % 2 == 1) odd++;
                if (odd > 1) return false;
            }
            return true;
        }

        
    }
}
