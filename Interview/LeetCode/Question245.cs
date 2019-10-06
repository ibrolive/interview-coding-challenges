using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question245
    {
        public int ShortestWordDistance(string[] words, string word1, string word2)
        {
            int result = Int32.MaxValue;
            Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();
            List<int> posWord1 = null,
                      posWord2 = null;

            for (int i = 0; i < words.Length; i++)
            {
                if (!dictionary.ContainsKey(words[i]))
                    dictionary.Add(words[i], new List<int>());

                dictionary[words[i]].Add(i);
            }

            if (word1 == word2)
            {
                posWord1 = dictionary[word1];
                posWord1.Sort();

                for (int i = 0; i < posWord1.Count - 1; i++)
                    if (Math.Abs(posWord1[i] - posWord1[i + 1]) < result)
                        result = Math.Abs(posWord1[i] - posWord1[i + 1]);
            }
            else
            {
                posWord1 = dictionary[word1];
                posWord2 = dictionary[word2];

                for (int i = 0; i < posWord1.Count; i++)
                    for (int j = 0; j < posWord2.Count; j++)
                        if (Math.Abs(posWord1[i] - posWord2[j]) < result)
                            result = Math.Abs(posWord1[i] - posWord2[j]);
            }

            return result;
        }
    }
}
