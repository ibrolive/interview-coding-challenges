using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question150
    {
        public int EvalRPN(string[] tokens)
        {
            if (tokens == null || tokens.Length == 0)
                return 0;

            Stack<string> stack = new Stack<string>();
            string[] operators = new string[] { "+", "-", "*", "/" };
            int num1 = 0,
                num2 = 0;

            for (int i = 0; i < tokens.Length; i++)
            {
                if (operators.Contains<string>(tokens[i]))
                {
                    num1 = Convert.ToInt32(stack.Pop());
                    num2 = Convert.ToInt32(stack.Pop());

                    if (tokens[i] == "+")
                        stack.Push((num2 + num1).ToString());
                    else if (tokens[i] == "-")
                        stack.Push((num2 - num1).ToString());
                    else if (tokens[i] == "*")
                        stack.Push((num2 * num1).ToString());
                    else
                        stack.Push((num2 / num1).ToString());
                }
                else
                    stack.Push(tokens[i]);
            }

            return Convert.ToInt32(stack.Pop());
        }
    }
}
