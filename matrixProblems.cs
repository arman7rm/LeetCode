using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class matrixProblems
    {
        public static bool Exist(char[][] board, string word)
        {
            List<Point> starts = new List<Point>();
            //O(N*M)
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    char first = word[0];
                    if (board[i][j] == first)
                    {
                        starts.Add(new Point(i, j));
                    }
                }
            }
            // O(P*R)
            foreach (Point start in starts)
            {
                Point curr = start;
                Point prev = new Point(-1, -1);
                int i = 1;
                while (i < word.Length)
                {
                    if (helper(board, curr, word[i], prev) != null)
                    {
                        if (i == word.Length - 1)
                        {
                            return helper(board, curr, word[i], prev) != null;
                        }
                        Point temp = curr;
                        curr = helper(board, curr, word[i], prev);
                        prev = temp;
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }
#nullable enable
        public static Point? helper(char[][] board, Point curr, char target, Point prev)
        {
            bool north = true, south = true, east = true, west = true;
            if (curr.x == 0 || ((curr.x - 1) == prev.x && (curr.y) == prev.y)) north = false;
            if (curr.x == board.Length - 1 || ((curr.x + 1) == prev.x && (curr.y) == prev.y)) south = false;
            if (curr.y == 0 || ((curr.x) == prev.x && (curr.y - 1) == prev.y)) west = false;
            if (curr.y == board[0].Length - 1 || ((curr.x) == prev.x && (curr.y + 1) == prev.y)) east = false;
            if (north)
            {
                if (board[curr.x - 1][curr.y] == target)
                {
                    return new Point((curr.x - 1), curr.y);
                }
            }
            if (south)
            {
                if (board[curr.x + 1][curr.y] == target)
                {
                    return new Point((curr.x + 1), curr.y);
                }
            }
            if (east)
            {
                if (board[curr.x][curr.y + 1] == target)
                {
                    return new Point(curr.x, (curr.y + 1));
                }
            }
            if (west)
            {
                if (board[curr.x][curr.y - 1] == target)
                {
                    return new Point(curr.x, (curr.y - 1));
                }
            }
            return null;
        }
    }
    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
