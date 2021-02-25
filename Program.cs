using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCode
{
    class Program {
        static void Main(string[] args)
        {
            int[] x = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int[][] y = new int[10][];
            y[0]=new int[] {1,100 } ;
            y[1] = new int[] { 7, 100 };
            y[2] = new int[] { 1, 100 };
            y[3] = new int[] { 7, 100 };
            y[4] = new int[] { 1, 100 };
            y[5] = new int[] { 7, 100 };
            y[6] = new int[] { 1, 100 };
            y[7] = new int[] { 7, 100 };
            y[8] = new int[] { 1, 100 };
            y[9] = new int[] { 7, 100 };
            // Display the number of command line arguments.
            Console.WriteLine(Goldman.reachingPoints(1,1,3,5));
        }
    }
}
