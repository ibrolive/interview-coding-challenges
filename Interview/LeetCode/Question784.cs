using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question784
    {
        public static void EntryPoint()
        {
            (new Question784()).LetterCasePermutation("a1b2");
        }

        public IList<string> LetterCasePermutation(string S)
        {
            IList<string> result = new List<string>();

            Helper(S, 0, new char[S.Length], result);

            return result;
        }

        private void Helper(string source, int index, char[] current, IList<string> result)
        {
            char[] temp = new char[source.Length];

            if (index == source.Length)
            {
                result.Add(new string(current));
                return;
            }

            if (source[index] >= '0' && source[index] <= '9')
            {
                current[index] = source[index];
                Helper(source, index + 1, current, result);
            }
            else
            {
                current.CopyTo(temp, 0);
                temp[index] = source[index] >= 'a' && source[index] <= 'z' ? (char)(source[index] - 32) : source[index];
                Helper(source, index + 1, temp, result);

                current.CopyTo(temp, 0);
                temp[index] = source[index] >= 'A' && source[index] <= 'Z' ? (char)(source[index] + 32) : source[index];
                Helper(source, index + 1, temp, result);
            }
        }
    }
}
