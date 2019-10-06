using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question557
    {
        public static void EntryPoint()
        {
            (new Question557()).ReverseWords("Let's take LeetCode contest");
        }

        public string ReverseWords(string s)
        {
            char spliter = ' ';
            char[] array = s.ToCharArray();
            int index = 0,
                startIndex = 0,
                endIndex = 0;

            while (index <= array.Length - 1)
            {
                if (array[index] == spliter || index == array.Length - 1)
                {
                    if (array[index] == spliter)
                        endIndex = index - 1;
                    else
                        endIndex = index;

                    while (startIndex < endIndex)
                    {
                        array[startIndex] = (char)((int)array[startIndex] + (int)array[endIndex]);
                        array[endIndex] = (char)((int)array[startIndex] - (int)array[endIndex]);
                        array[startIndex] = (char)((int)array[startIndex] - (int)array[endIndex]);

                        startIndex++;
                        endIndex--;
                    }

                    startIndex = index + 1;
                }

                index++;
            }

            return new string(array);
        }
    }
}