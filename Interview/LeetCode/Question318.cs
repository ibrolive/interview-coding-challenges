using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question318
    {
        public static void EntryPoint()
        {
            (new Question318()).MaxProduct(new string[] { "bac" });
        }

        public int MaxProduct(string[] words)
        {
            int[] wordMasks = new int[words.Length];
            int result = 0;

            for (int i = 0; i < words.Length; i++)
                wordMasks[i] = GetMask(words[i]);

            for (int i = 0; i < words.Length; i++)
                for (int j = 0; j < words.Length; j++)
                    if (i != j && (wordMasks[i] & wordMasks[j]) == 0)
                        result = Math.Max(result, words[i].Length * words[j].Length);

            return result;
        }

        private int GetMask(string word)
        {
            int mask = 0;

            foreach (var item in word)
                mask |= 1 << item - 'a';

            return mask;
        }
    }
}
