using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question58
    {
        public static void EntryPoint()
        {
            (new Question58()).LengthOfLastWord("a ");
        }

        public int LengthOfLastWord(string s)
        {
            if (s.Length == 0 || s == string.Empty || s == " ")
                return 0;

            int startIndex = 0,
                endIndex = s.Length - 1,
                currentIndex = s.Length - 1;

            bool foundEndIndex = false;

            if (s[s.Length - 1] != ' ')
                foundEndIndex = true;

            while (currentIndex >= 0)
            {
                if (!foundEndIndex)
                {
                    if (s[currentIndex] != ' ')
                        foundEndIndex = true;

                    endIndex = currentIndex;
                }

                if (foundEndIndex && s[currentIndex] == ' ')
                {
                    startIndex = currentIndex + 1;
                    break;
                }

                currentIndex--;
            }

            return s[endIndex] == ' ' ? 0 : endIndex - startIndex + 1;
        }
    }
}