using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question737
    {
        public static void EntryPoint()
        {
            string[] words1 = { "great", "acting", "skills" },
                     words2 = { "fine", "drama", "talent" };
            string[][] pairs = new string[4][];
            pairs[0] = new string[] { "great", "good" };
            pairs[1] = new string[] { "fine", "good" };
            pairs[2] = new string[] { "drama", "acting" };
            pairs[3] = new string[] { "skills", "talent" };

            (new Question737()).AreSentencesSimilarTwo(words1, words2, pairs);
        }

        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, string[][] pairs)
        {
            if (words1 == words2 ||
                (words1 == null && words2 != null) ||
                (words1 != null && words2 == null) ||
                words1.Length != words2.Length)
                return false;

            DisjointSet set = new DisjointSet(pairs.Length * 2);
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            int count = 0;
            string word1 = string.Empty,
                   word2 = string.Empty;

            for (int i = 0; i < pairs.Length; i++)
            {
                for (int j = 0; j < pairs[i].Length; j++)
                    if (!dictionary.Keys.Contains(pairs[i][j]))
                        dictionary.Add(pairs[i][j], count++);

                set.Union(dictionary[pairs[i][0]], dictionary[pairs[i][1]]);
            }

            for (int i = 0; i < words1.Length; i++)
            {
                word1 = words1[i];
                word2 = words2[i];

                if (word1 == word2)
                    continue;

                if (!dictionary.Keys.Contains(word1) ||
                    !dictionary.Keys.Contains(word2) ||
                    set.Find(dictionary[word1]) != set.Find(dictionary[word2]))
                    return false;
            }

            return true;
        }

        class DisjointSet
        {
            private int[] _parent = null;

            public DisjointSet(int n)
            {
                _parent = new int[n];

                for (int i = 0; i < n; i++)
                    _parent[i] = i;
            }

            public int Find(int n)
            {
                if (_parent[n] != n)
                    _parent[n] = Find(_parent[n]);

                return _parent[n];
            }

            public void Union(int x, int y)
            {
                _parent[Find(x)] = Find(y);
            }
        }
    }
}
