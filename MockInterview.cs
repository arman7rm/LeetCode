using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{

    public class SnakeGame
    {

        /** Initialize your data structure here.
            @param width - screen width
            @param height - screen height 
            @param food - A list of food positions
            E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */

        public int w;
        public int h;
        public int[][] food;
        public int foodIndex = 0;
        List<int[]> pos = new List<int[]>();
        public int length;

        public SnakeGame(int width, int height, int[][] food)
        {
            this.w = width;
            this.h = height;
            this.food = food;
            this.pos.Add(new int[] { 0, 0 });
        }

        /** Moves the snake.
            @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
            @return The game's score after the move. Return -1 if game over. 
            Game over when snake crosses the screen boundary or bites its body. */
        public int Move(string direction)
        {
            switch (direction)
            {
                case "U":
                    int headRow = pos[pos.Count - 1][0];
                    if (headRow == 0)
                    {
                        return -1;
                    }
                    int[] newHead = pos[pos.Count - 1];
                    newHead[0]--;
                    if (newHead.SequenceEqual(food[foodIndex]) && foodIndex < food.Length)
                    {
                        foodIndex++;
                        pos.Add(newHead);
                    }
                    else
                    {
                        pos.Add(newHead);
                        pos.RemoveAt(0);
                    }
                    return pos.Count - 1;

                case "D":
                    headRow = pos[pos.Count - 1][0];
                    if (headRow == h - 1)
                    {
                        return -1;
                    }
                    newHead = pos[pos.Count - 1];
                    newHead[0]++;
                    if (newHead.SequenceEqual(food[foodIndex]) && foodIndex < food.Length)
                    {
                        foodIndex++;
                        pos.Add(newHead);
                    }
                    else
                    {
                        pos.Add(newHead);
                        pos.RemoveAt(0);
                    }
                    return pos.Count - 1;
                case "L":
                    int headCol = pos[pos.Count - 1][1];
                    if (headCol == 0)
                    {
                        return -1;
                    }
                    newHead = pos[pos.Count - 1];
                    newHead[1]--;
                    if (newHead.SequenceEqual(food[foodIndex]) && foodIndex < food.Length)
                    {
                        foodIndex++;
                        pos.Add(newHead);
                    }
                    else
                    {
                        pos.Add(newHead);
                        pos.RemoveAt(0);
                    }
                    return pos.Count - 1;
                case "R":
                    headCol = pos[pos.Count - 1][1];
                    if (headCol == (w - 1))
                    {
                        return -1;
                    }
                    newHead = pos[pos.Count - 1];
                    newHead[1]++;
                    if (newHead.SequenceEqual(food[foodIndex]) && foodIndex < food.Length)
                    {
                        foodIndex++;
                        pos.Add(newHead);
                    }
                    else
                    {
                        pos.Add(newHead);
                        pos.RemoveAt(0);
                    }
                    return pos.Count - 1;

                default:
                    return -1;

            }
        }
    }

    /**
     * Your SnakeGame object will be instantiated and called as such:
     * SnakeGame obj = new SnakeGame(width, height, food);
     * int param_1 = obj.Move(direction);
     */
    class MockInterview

    {
        // "Bloomberg"          --> bbooeglmr
        
        public string frequencySort(string a)
        {
            a.ToLower();
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            SortedDictionary<int, List<char>> sortedMap = new SortedDictionary<int, List<char>>();
            StringBuilder result = new StringBuilder();

            for(int i=0; i<a.Length; i++)
            {
                if (freqMap.ContainsKey(a[i]))
                {
                    freqMap[a[i]]++;
                }
                else
                {
                    freqMap.Add(a[i],1);
                }
            }
            foreach(KeyValuePair<char, int> kvp in freqMap)
            {
                if (sortedMap.ContainsKey(kvp.Value))
                {
                    sortedMap[kvp.Value].Add(kvp.Key);
                }
                else
                {
                    sortedMap.Add(kvp.Value, new List<char>());

                }
            }
            foreach(KeyValuePair<int, List<char>> kvp in sortedMap)
            {
                kvp.Value.Sort();
                foreach (char x in kvp.Value)
                {
                    int frequency = kvp.Key;
                    while (frequency > 0)
                    {
                        result.Append(x);
                        frequency--;
                    }
                }
            }
            return result.ToString(); 
        }

    }
}
