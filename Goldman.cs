using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Goldman
    {
        public static int problem1(string pool)
        {
            int last = 0;
            for(int i=0; i<pool.Length; i++)
            {
                if (pool[i] == '8') last = i;
            }
            StringBuilder temp = new StringBuilder();
            return "";
        }
        public static int Compress(char[] chars)
        {
            if (chars.Length == 1)
            {
                return 1;
            }
            StringBuilder s = new StringBuilder();
            char curr = chars[0];
            int freq = 1;
            for(int i=1; i<chars.Length; i++)
            {

                if(chars[i] == curr)
                {
                    freq++;
                    if (i == chars.Length - 1)
                    {
                        s.Append(curr);
                        curr = chars[i];
                        if (freq != 1) s.Append(freq);
                    }
                }
                else
                {
                    s.Append(curr);
                    curr = chars[i];
                    if (freq != 1) s.Append(freq);
                    freq = 1;
                }
            }
            string k = s.ToString();
            for(int j=0; j<chars.Length; j++)
            {
                if (j < k.Length)
                {
                    chars[j] = k[j];
                }
                else
                {
                    var foos = new List<char>(chars);
                    foos.RemoveAt(j);
                    chars = foos.ToArray();
                }
            }
            return k.Length;
        }
        public static bool IsRobotBounded(string instructions)
        {
            string x = instructions;
            int[] pos = new int[] { 0, 0 };
            int[,] dirs = new int[,] { { 0, 1 }, { -1, 0 }, { 0, -1 }, { 1, 0 } };
            int dir = 0;
            foreach (char s in x)
            {
                if (s == 'L') dir = (dir + 1) % 4;
                else if (s == 'R') dir = (dir + 3) % 4;
                else
                {
                    pos[0] += dirs[dir, 0];
                    pos[1] += dirs[dir, 1];
                }
            }
            return (pos[0] == 0 && pos[1] == 0) || dir != 0;
        }
        public static bool ReachingPoints(int sx, int sy, int tx, int ty)
        {
            while (sx < tx && sy < ty)
            {
                if (tx < ty)
                {
                    ty %= tx;
                }
                else
                {
                    tx %= ty;
                }
            }
            if (sx == tx && sy <= ty && (ty - sy) % sx == 0)
                return true;

            return sy == ty && sx <= tx && (tx - sx) % sy == 0;
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
                for (int m = 0; m < 5; m++)
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
