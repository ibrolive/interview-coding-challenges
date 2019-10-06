using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1047
    {
        public string RemoveDuplicates(string S)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var item in S)
            {
                if (stack.Count > 0 && stack.Peek() == item)
                {
                    stack.Pop();
                    continue;
                }

                stack.Push(item);
            }

            return new string(stack.ToArray().Reverse<char>().ToArray<char>());
        }
    }
}
