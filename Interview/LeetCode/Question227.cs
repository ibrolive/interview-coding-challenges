using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question227
    {
        public static void EntryPoint()
        {
            (new Question227()).Calculate("3+2*2");
        }

        public int Calculate(string s)
        {
            Stack<int> stack = new Stack<int>();
            char sign = '+';
            int temp = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                    temp = temp * 10 + (s[i] - '0');

                if ((s[i] != ' ' && !char.IsDigit(s[i])) || i == s.Length - 1)
                {
                    if (sign == '+')
                        stack.Push(temp);
                    else if (sign == '-')
                        stack.Push(-temp);
                    else if (sign == '*')
                        stack.Push(stack.Pop() * temp);
                    else if (sign == '/')
                        stack.Push(stack.Pop() / temp);

                    sign = s[i];
                    temp = 0;
                }
            }

            temp = 0;
            while (stack.Count > 0)
                temp += stack.Pop();

            return temp;
        }
    }
}
