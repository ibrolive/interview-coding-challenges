using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question394
    {
        public static void EntryPoint()
        {
            (new Question394()).DecodeString("sd2[f2[e]g]i");
        }

        public string DecodeString(string s)
        {
            string result = string.Empty,
                   baseString = string.Empty,
                   temp = string.Empty,
                   tail = string.Empty;
            Stack<char> stack = new Stack<char>();
            int repeatCount = 0,
                digit = 0;

            foreach (var item in s)
            {
                if (item != ']')
                {
                    stack.Push(item);

                    continue;
                }
                else
                {
                    while (stack.Count != 0 && stack.Peek() != '[')
                        baseString = stack.Pop().ToString() + baseString;

                    stack.Pop();

                    while (stack.Count != 0 && stack.Peek() <= 57)
                        repeatCount = ((int)stack.Pop() - 48) * (int)Math.Pow(10, digit++) + repeatCount;

                    for (int i = 1; i <= repeatCount; i++)
                        temp += baseString;

                    if (stack.Count == 0)
                        result += temp;
                    else
                        foreach (var itemInTemp in temp)
                            stack.Push(itemInTemp);

                    baseString = string.Empty;
                    temp = string.Empty;
                    repeatCount = 0;
                    digit = 0;
                }
            }

            while (stack.Count != 0)
                tail = stack.Pop().ToString() + tail;

            return result + tail;
        }
    }
}