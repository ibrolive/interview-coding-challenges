using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question12
    {
        public static void EntryPoint()
        {
            (new Question12()).IntToRoman(89);
        }

        public string IntToRoman(int num)
        {
            int count = 0;
            Stack<string> stack = new Stack<string>();
            StringBuilder result = new StringBuilder();

            while (num != 0)
            {
                if (num % 10 == 9)
                    stack.Push(count == 0 ? "IX" :
                               count == 1 ? "XC" :
                               count == 2 ? "CM" : string.Empty);
                else if (num % 10 == 4)
                    stack.Push(count == 0 ? "IV" :
                               count == 1 ? "XL" :
                               count == 2 ? "CD" : string.Empty);
                else if (num % 10 >= 5 && num % 10 < 9)
                {
                    for (int i = num % 10 - 5; i > 0; i--)
                        stack.Push(count == 0 ? "I" :
                                   count == 1 ? "X" :
                                   count == 2 ? "C" :
                                   count == 3 ? "M" : string.Empty);

                    stack.Push(count == 0 ? "V" :
                               count == 1 ? "L" :
                               count == 2 ? "D" : string.Empty);
                }
                else if (num % 10 > 0 && num % 10 < 5)
                    for (int i = num % 10; i > 0; i--)
                        stack.Push(count == 0 ? "I" :
                                   count == 1 ? "X" :
                                   count == 2 ? "C" :
                                   count == 3 ? "M" : string.Empty);

                count++;
                num /= 10;
            }

            while (stack.Count != 0)
                result.Append(stack.Pop());

            return result.ToString();
        }
    }
}
