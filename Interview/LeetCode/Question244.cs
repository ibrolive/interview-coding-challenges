using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question244
    {
        public class WordDistance
        {
            Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();

            public WordDistance(string[] words)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (!dictionary.ContainsKey(words[i]))
                        dictionary.Add(words[i], new List<int>());

                    dictionary[words[i]].Add(i);
                }

            }

            public int Shortest(string word1, string word2)
            {
                int result = Int32.MaxValue;
                List<int> posWord1 = dictionary[word1];
                List<int> posWord2 = dictionary[word2];

                for (int i = 0; i < posWord1.Count; i++)
                    for (int j = 0; j < posWord2.Count; j++)
                        if (Math.Abs(posWord1[i] - posWord2[j]) < result)
                            result = Math.Abs(posWord1[i] - posWord2[j]);

                return result;
            }
        }
    }
}
