﻿using System;
using System.Collections.Generic;

namespace LeetCode
{
    class AlgoEasy
    {
        //magicIndex
        public static int magicIndex(int[] arr)
        {
            int l = 0, r = arr.Length - 1;
            return magicIndex(arr, l, r);
        }

        private static int magicIndex(int[] arr, int l, int r)
        {

            int m = (l + r) / 2;
            if (m == arr[m]) return m;
            if (m > arr[m])
            {
                return magicIndex(arr, m+1, r);
            }
            return magicIndex(arr, l, m-1);
        }


        //child is running up a staircase with n steps, and can hop 1-3steps at a time. how many possible ways can the child move up
        public static int stairs(int n)
        {
            int[] mem = new int[n+1];
            Array.Fill(mem, -1);
            return stairs(n, mem);
        }

        private static int stairs(int n, int[] mem)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;
            if (mem[n] > -1) return mem[n];
            if (mem[n] == -1) mem[n] = stairs(n-1, mem) + stairs(n-2, mem) + stairs(n-3,mem);
            return mem[n];
        }

        public static int dpFib(int n)
        {
            return dpFib(n, new int[n + 1]);
        }

        public static int dpFib(int n, int[] fibs)
        {
            if (n == 0 || n == 1) return n;
            if (fibs[n] == 0) fibs[n] = dpFib(n - 1, fibs) + dpFib(n - 2, fibs);
            return fibs[n];
        }
        public static int mskcc(string S)
        {
            bool change = S[0] == 'A' ? false : true;
            int l = 0, r = S.Length-1;
            int del = 0;
            while (l > r)
            {
                if (S[l] == 'A')
                {
                    l++;
                }
                else
                {
                    
                }
                if (S[r] == 'B')
                {
                    r--;
                }
            }
            return del;
        }
        public static int mskcc2(int N)
        {
            if (N == 0) return 50;
            if (N < 0)
            {
                int tmp = N * -1;
                int pow = 0;
                while (tmp > 0)
                {
                    tmp /= 10;
                    pow++;
                }
                return N - ((int)Math.Pow(10, pow) * 5);
            }
            int temp = N;
            List<int> list = new List<int>();
            while (temp > 0)
            {
                list.Add(temp % 10);
                temp /= 10;
            }
            bool added = false;
            for(int i=list.Count-1; i>=0; i--)
            {
                if (list[i] < 5)
                {
                    list.Insert(i+1, 5);
                    added = true;
                    break;
                }
            }
            if (!added)
            {
                list.Reverse();
                list.Add(5);
                list.Reverse();
            }
            int sum = 0;
            int y = 1;
            foreach(int x in list)
            {
                int curr = y * x;
                sum += curr;
                y*=10;
            }
            return sum;

        }
        public static int NonConstructibleChange(int[] coins)
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
    }
}
