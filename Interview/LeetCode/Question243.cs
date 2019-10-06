using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question243
    {
        public int ShortestDistance(string[] words, string word1, string word2)
        {
            int index1 = -1,
                index2 = -1,
                result = Int32.MaxValue;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word1)
                    index1 = i;
                else if (words[i] == word2)
                    index2 = i;

                if (index1 != -1 && index2 != -1)
                    result = Math.Min(result, Math.Abs(index1 - index2));
            }

            return result;
        }
    }
}
