using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question8
    {
        public static void EntryPoint()
        {
            (new Question8()).MyAtoi("a");
        }

        public int MyAtoi(string str)
        {
            int index = 0, sign = 1, total = 0, digit = 0;

            //1. Empty string
            if (str.Length == 0)
                return 0;

            //2. Remove Spaces
            //while (str.charAt(index) == ' ' && index < str.length())
            //    index++;

            //3. Handle signs
            //if (str.charAt(index) == '+' || str.charAt(index) == '-')
            //{
            //    sign = str.charAt(index) == '+' ? 1 : -1;
            //    index++;
            //}

            //4. Convert number and avoid overflow
            while (index < str.Length)
            {
                digit = str[index] - '0';
                if (digit < 0 || digit > 9)
                    break;

                //check if total will be overflow after 10 times and add digit
                if (int.MaxValue / 10 < total || int.MaxValue / 10 == total && int.MaxValue % 10 < digit)
                    return sign == 1 ? int.MaxValue : int.MinValue;

                total = 10 * total + digit;
                index++;
            }

            return total * sign;
        }
    }
}