using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question293
    {
        public IList<string> GeneratePossibleNextMoves(string s)
        {
            StringBuilder builder = new StringBuilder(s);
            IList<string> result = new List<string>();

            for (int i = 0; i < s.Length - 1; i++)
                if (s[i] == '+' && s[i + 1] == '+')
                {
                    builder[i] = '-';
                    builder[i + 1] = '-';
                    result.Add(builder.ToString());
                    builder[i] = '+';
                    builder[i + 1] = '+';
                }

            return result;
        }
    }
}
