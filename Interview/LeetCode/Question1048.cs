using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1048
    {
        public int LongestStrChain(string[] words)
        {
            int res = 0;
            Dictionary<string, int> _dictionary = new Dictionary<string, int>();

            Array.Sort(words, (a, b) => a.Length - b.Length);

            foreach (string word in words)
            {
                _dictionary[word] = 1;

                for (int i = 0; i < word.Length; i++)
                {
                    StringBuilder sb = new StringBuilder(word);
                    sb.Remove(i, 1);
                    string next = sb.ToString();

                    if (_dictionary.ContainsKey(next) && _dictionary[next] + 1 > _dictionary[word])
                        _dictionary[word] = _dictionary[next] + 1;
                }

                res = Math.Max(res, _dictionary[word]);
            }

            return res;
        }
    }
}
