using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCode
{
    /*
     *      4
     *    2   6
     *    2 4 6
     * 
     *      1
     *    2   6
     * 2 1 6
     */
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(mskcc(-999));
        }

        public static int mskcc(int N)
        {
            List<int> list = new List<int>();
            bool neg = N < 0;
            while (N != 0)
            {
                list.Add(Math.Abs(N%10));
                N /= 10;
            }
            int pw = list.Count,ans=0;
            bool added = false;
            for(int i=list.Count-1; i>=0; i--)
            {
                if (neg && list[i] > 5 && !added)
                {
                    ans += (5 * (int)Math.Pow(10, pw));
                    pw--;
                    added = true;
                }
                else if(list[i] < 5 && !added)
                {
                    ans += (5 * (int)Math.Pow(10, pw));
                    pw--;
                    added = true;
                }
                ans+= (list[i] * (int)Math.Pow(10, pw));
                pw--;
            }
            if (neg) ans *= -1;
            return ans;
            //StringBuilder ans = new StringBuilder();
            //if (N < 0) ans.Append('-');
            //string n = N.ToString();
            //if (N < 0) n = n.Substring(1);
            //for (int i = 0; i < n.Length; i++)
            //{
            //    int temp = (int)n[i] - 48;
            //    if (N >= 0)
            //    {
            //        if (temp < 5)
            //        {
            //            ans.Append('5');
            //            ans.Append(n.Substring(i));
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        if (temp > 5)
            //        {
            //            ans.Append('5');
            //            ans.Append(n.Substring(i));
            //            break;
            //        }
            //    }
            //    ans.Append(n[i]);
            //}
            //return ans.ToString();
        }
    }
}
