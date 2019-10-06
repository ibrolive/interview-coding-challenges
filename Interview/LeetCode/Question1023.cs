using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1023
    {
        public IList<bool> CamelMatch(string[] queries, string pattern)
        {
            IList<bool> result = new List<bool>();

            foreach (var query in queries)
            {
                bool match = true;
                int pi = 0,
                    i = 0;

                while (i < query.Length)
                {
                    if (pi < pattern.Length && query[i] == pattern[pi])
                        pi++;
                    else if (Char.IsUpper(query[i]))
                    {
                        match = false;
                        break;
                    }

                    i++;
                }

                result.Add(match && pi == pattern.Length);
            }

            return result;
        }
    }
}
