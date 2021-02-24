using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
	using System;
	using System.Collections.Generic;

	public class DFS
	{
		public static int NodeDepths(BinaryTree root)
		{
			// Write your code here.
			int sum = 0;
			Queue<BinaryTree> q = new Queue<BinaryTree>();
			q.Enqueue(root);
			double i = 1;
			sum = BFS(root, sum, q, i);
			return sum;
		}
		public static int BFS(BinaryTree root, int sum, Queue<BinaryTree> q, double i)
		{
			while (q.Count > 0)
			{
				BinaryTree curr = q.Dequeue();
				if (curr != null)
				{
					double x = i;
					int l = (int)Math.Log(x, 2.00);
					i++;
					sum += l;
					q.Enqueue(curr.left);
					q.Enqueue(curr.right);
				}
			}
			return sum;
		}

		public class BinaryTree
		{
			public int value;
			public BinaryTree left;
			public BinaryTree right;

            public BinaryTree()
            {
            }

            public BinaryTree(int value)
			{
				this.value = value;
				left = null;
				right = null;
			}
		}
	}
}
