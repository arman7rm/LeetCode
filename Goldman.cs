using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Goldman
    {
        public static bool reachingPoints(int sx, int sy, int tx, int ty)
        {
            if (sx == tx && sy == ty)
                return true;

            if (sx > tx || sy > ty)
                return false;

            return (reachingPoints(sx + sy, sy, tx, ty) || reachingPoints(sx, sx + sy, tx, ty));
        }
        public static int TrappingRainwater(int[] height)
        {
            List<int> waterLevel = new List<int>();
            int curr = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > curr) curr = height[i];
                waterLevel.Add(curr);
            }
            curr = 0;
            for (int j = height.Length - 1; j >= 0; j--)
            {
                if (height[j] > curr) curr = height[j];
                if (waterLevel[j] > curr) waterLevel[j] = curr;
            }
            int bucket = 0;
            for (int k = 0; k < height.Length; k++)
            {
                int water = waterLevel[k] - height[k];
                bucket += water;
            }
            return bucket;
        }

        public static int[][] HighFive(int[][] items)
        {
            SortedDictionary<int, List<int>> map = new SortedDictionary<int, List<int>>();
            for (int i = 0; i < items.Length; i++)
            {
                int id = items[i][0];
                int score = items[i][1];
                if (!map.ContainsKey(id))
                {
                    map.Add(id, new List<int>());
                }
                map[id].Add(score);
            }
            int[][] result = new int[map.Count][];
            int j = 0;
            foreach (KeyValuePair<int, List<int>> kvp in map)
            {
                int total = 0;
                kvp.Value.Sort();
                kvp.Value.Reverse();
                for (int m=0; m<5; m++)
                {
                    total += kvp.Value[m];
                }
                int avg = total / 5;
                result[j] = new int[] { kvp.Key, avg };
                j++;
            }
            return result;
        }

    }
}
