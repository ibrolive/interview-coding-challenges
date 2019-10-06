using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question155
    {
        private long min = 0;
        Stack<long> stack = new Stack<long>();

        public void push(int x)
        {
            stack.Push(x);
            if (x < min) min = x;
        }

        public void pop()
        {
            if (stack.Count == 0)
                return;

            long pop = stack.Pop();

            if (pop < 0) min = min - pop;
        }

        public int top()
        {
            long top = stack.Peek();
            if (top > 0)
            {
                return (int)(top + min);
            }
            else
            {
                return (int)(min);
            }
        }

        public int getMin()
        {
            return (int)min;
        }
    }
}