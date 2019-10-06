using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question38
    {
        public static void EntryPoint()
        {
            (new Question38()).CountAndSay(4);
        }

        public string CountAndSay(int n)
        {
            if (n == 1)
                return "1";

            string result = "1", tempResult = string.Empty;
            int index = 1, count = 1;
            char currentChar = result[0];

            for (int i = 2; i <= n; i++)
            {
                while (index <= result.Length - 1)
                {
                    if (currentChar == result[index])
                        count++;
                    else
                    {
                        tempResult += count.ToString() + currentChar;
                        currentChar = result[index];
                        count = 1;
                    }

                    index++;
                }

                result = tempResult + count.ToString() + currentChar;

                count = 1;
                index = 1;
                tempResult = string.Empty;
                currentChar = result[0];
            }

            return result;
        }
    }
}