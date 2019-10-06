using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question459
    {
        public static void EntryPoint()
        {
            (new Question459()).RepeatedSubstringPattern("aaaaaaaaaaaaaaaaaaaaa");
        }

        public bool RepeatedSubstringPattern(string s)
        {
            bool result = false,
                 currentLoop = true;
            int startIndex = 0,
                index = 0;

            for (int i = 1; i <= s.Length / 2; i++)
            {
                currentLoop = true;
                startIndex = 0;

                for (int j = 1; j <= i; j++)
                {
                    index = startIndex + i;

                    while (index < s.Length)
                        if (s[startIndex] != s[index])
                        {
                            currentLoop = false;
                            break;
                        }
                        else
                            index += i;

                    if (!currentLoop)
                        break;

                    if (j == i && index - i == s.Length - 1)
                        result = true;

                    startIndex++;
                }

                if (result)
                    break;
            }

            return result;
        }
    }
}
