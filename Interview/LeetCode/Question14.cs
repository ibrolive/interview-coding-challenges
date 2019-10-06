using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question14
    {
        public static void EntryPoint()
        {
            string[] input = { "a", "b" };
            (new Question14()).LongestCommonPrefix(input);
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;
            else if (strs.Length == 1)
                return strs[0];

            bool loopContinue = true;
            int charIndex = 0;
            char currentChar;
            StringBuilder prefix = new StringBuilder();

            while (true)
            {
                if (charIndex <= strs[0].Length - 1)
                    currentChar = strs[0][charIndex];
                else
                    break;

                for (int stringIndex = 1; stringIndex <= strs.Length - 1; stringIndex++)
                {
                    if (charIndex > strs[stringIndex].Length - 1 || strs[stringIndex][charIndex] != currentChar)
                    {
                        loopContinue = false;
                        break;
                    }
                }

                if (!loopContinue)
                    break;

                prefix.Append(currentChar);
                charIndex++;
            }

            return prefix.ToString();
        }
    }
}