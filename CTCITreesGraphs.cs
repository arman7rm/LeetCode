using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    class CTCITreesGraphs
    {
        public class node
        {
            public int val;
            public node left;
            public node right;
            public node(int x)
            {
                this.val = x;
                this.left = null;
                this.right = null;
            }
        }
        public static node minimumTree(int[] arr)
        {
            node root = minimumTree(arr, 0, arr.Length-1);
            return root;
        }

        private static node minimumTree(int[] arr, int l, int r)
        {
            if (l > r) return null;
            int m = (l + r) / 2;
            node root = new node(arr[m]);
            root.right = minimumTree(arr, m + 1, r);
            root.left = minimumTree(arr, l, m-1);
            return root;

        }

        //algo expert tree
        public static int MaxPathSum(node tree)
        {
            // Write your code here.
            if (tree == null) return -1;
            List<int> leftSums = new List<int>(), rightSums = new List<int>(), list = new List<int>();
            inOrderTrav(tree.left, 0, leftSums, list);
            inOrderTrav(tree.right, 0, rightSums, list);
            int leftSum = leftSums.Max();
            int rightSum = rightSums.Max();
            return Math.Max(leftSum + rightSum + tree.val, list.Max()) ;
        }

        public static void inOrderTrav(node tree, int curr, List<int> sums, List<int> list)
        {
            if (tree != null)
            {
                curr += tree.val;
                list.Add(tree.val);
                inOrderTrav(tree.left, curr, sums, list);
                inOrderTrav(tree.right, curr, sums, list);
                curr -= tree.val;
            }
            sums.Add(curr);
        }

    }
}
