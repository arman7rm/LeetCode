using System;
using System.Collections.Generic;
using System.Text;

namespace Algo
{
    public class Trees
    {
    }
	public class Node
	{
		public string name;
		public List<Node> children = new List<Node>();

		public Node(string name)
		{
			this.name = name;
		}

		public List<string> DepthFirstSearch(List<string> array)
		{
			// Write your code here.
			if (this != null)
			{
				array.Add(this.name);
				foreach (Node child in this.children)
				{
					array=child.DepthFirstSearch(array);
				}
			}
			return array;
		}

		public Node AddChild(string name)
		{
			Node child = new Node(name);
			children.Add(child);
			return this;
		}
	}
}
