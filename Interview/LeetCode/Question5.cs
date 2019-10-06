using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question5
    {
        public static void EntryPoint()
        {
            (new Question5()).LongestPalindrome("babad");
        }

        public string LongestPalindrome(string s)
        {
            char[] input = s.ToCharArray();

            for (int endIndex = input.Length - 1; endIndex >= 0; endIndex--)
                for (int startIndex = 0; startIndex <= input.Length - 1; startIndex++)
                    if (IsPalindrome(input, startIndex, endIndex))
                        return s.Substring(startIndex, endIndex - startIndex + 1);

            return string.Empty;
        }

        private bool IsPalindrome(char[] input, int startIndex, int endIndex)
        {
            for (int i = startIndex, j = endIndex; i < j; i++, j--)
                if (input[i] != input[j])
                    return false;

            if (startIndex == endIndex)
                return false;
            else
                return true;
        }
    }
}