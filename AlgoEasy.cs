using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class AlgoEasy
    {
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
