using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question232
    {
        public class MyQueue
        {
            private Stack<int> stack1 = new Stack<int>();
            private Stack<int> stack2 = new Stack<int>();

            public MyQueue()
            {

            }

            public void Push(int x)
            {
                stack1.Push(x);
            }

            public int Pop()
            {
                int value = 0;

                if (stack1.Count != 0)
                {
                    while (stack1.Count > 1)
                        stack2.Push(stack1.Pop());

                    value = stack1.Pop();

                    while (stack2.Count > 0)
                        stack1.Push(stack2.Pop());
                }

                return value;
            }

            public int Peek()
            {
                int value = 0;

                if (stack1.Count != 0)
                {
                    while (stack1.Count > 1)
                        stack2.Push(stack1.Pop());

                    value = stack1.Pop();
                    stack1.Push(value);

                    while (stack2.Count > 0)
                        stack1.Push(stack2.Pop());
                }

                return value;
            }

            public bool Empty()
            {
                return stack1.Count == 0;
            }
        }
    }
}