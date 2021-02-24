using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class DinnerPlate
    {
        public List<List<int>> stacks;
        public List<int> stack;
        public int cap;
        public int stack_i = 0;

        public DinnerPlate(int capacity)
        {
            this.stacks = new List<List<int>>();
            this.stack = new List<int>();
            stacks.Add(this.stack);
            this.cap = capacity;
        }

        public void Push(int val)
        {
            int x = 0;
            List<int> temp = stacks[x];
            while(temp.Count == cap )
            {
                if (x == stacks.Count - 1)
                {
                    temp = new List<int>();
                    temp.Add(val);
                    stacks.Add(temp);
                    return;
                }
                x++;
                temp = stacks[x];
                
            }
            temp.Add(val);
            stacks[x] = temp;
            return;
        }

        public int Pop()
        {
            stack_i = stacks.Count - 1;
            if (stack_i == 0 && stack.Count == 0) return -1;
            int j = stack.Count-1;
            int popped = stacks[stack_i][j];
            if (j == 0)
            {
                stacks.RemoveAt(stack_i);
                stack_i--;
                j = cap-1;
            }
            stack = stacks[stack_i];
            stack.RemoveAt(j);
            stacks[stack_i] = stack;
            return popped;

        }

        public int PopAtStack(int index)
        {
            List<int> temp = stacks[index];
            if (index == 0 && temp.Count == 0) return -1;
            int j = temp.Count - 1;
            int popped = temp[j];
            temp.RemoveAt(j);
            stacks[index] = temp;
            return popped;
        }
    }
}
