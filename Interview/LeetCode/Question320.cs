using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question320
    {
        public static void EntryPoint()
        {
            (new Question320()).GenerateAbbreviations("word");
        }

        // https://leetcode.com/problems/generalized-abbreviation/solution/
        public List<String> GenerateAbbreviations(String word)
        {
            List<string> ans = new List<string>();

            backtrack(ans, new StringBuilder(), word, 0, 0);

            return ans;
        }

        private void backtrack(List<String> ans, StringBuilder builder, String word, int i, int k)
        {
            int len = builder.Length;

            if (i == word.Length)
            {
                if (k != 0)
                    builder.Append(k);

                ans.Add(builder.ToString());
            }
            else
            {
                backtrack(ans, builder, word, i + 1, k + 1);

                if (k != 0)
                    builder.Append(k);
                builder.Append(word[i]);
                backtrack(ans, builder, word, i + 1, 0);
            }

            builder.Remove(len, builder.Length - len);
        }
    }
}
