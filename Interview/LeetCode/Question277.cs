using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question277
    {
        // https://leetcode.com/problems/find-the-celebrity/discuss/71240/AC-Java-solution-using-stack
        public int FindCelebrity(int n)
        {
            if (n <= 0)
                return -1;

            if (n == 1)
                return 0;

            Stack<int> stack = new Stack<int>();
            int a = 0,
                b = 0,
                c = 0;

            for (int i = 0; i < n; i++)
                stack.Push(i);

            while (stack.Count > 1)
            {
                a = stack.Pop();
                b = stack.Pop();

                if (Knows(a, b))
                    stack.Push(b);
                else
                    stack.Push(a);
            }

            c = stack.Pop();

            for (int i = 0; i < n; i++)
                if (i != c && (Knows(c, i) || !Knows(i, c)))
                    return -1;

            return c;
        }

        private bool Knows(int a, int b)
        {
            return false;
        }
    }
}
