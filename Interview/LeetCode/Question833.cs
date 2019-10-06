using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question833
    {
        public static void EntryPoint()
        {
            (new Question833()).FindReplaceString("abcd", new int[] { 0, 2 }, new string[] { "a", "cd" }, new string[] { "eee", "ffff" });
        }

        public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets)
        {
            StringBuilder result = new StringBuilder();
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            int indexS = 0,
                indexT = 0;

            for (int i = 0; i < S.Length; i++)
                dictionary.Add(i, S[i].ToString());

            for (int i = 0; i < indexes.Length; i++)
            {
                indexS = indexes[i];
                indexT = 0;

                while (indexT < sources[i].Length && S[indexS] == sources[i][indexT])
                {
                    indexS++;
                    indexT++;
                }

                if (indexT == sources[i].Length)
                {
                    dictionary[indexes[i]] = targets[i];

                    for (int j = indexes[i] + 1; j < indexes[i] + sources[i].Length; j++)
                        dictionary.Remove(j);
                }
            }

            foreach (var item in dictionary.Values)
                result.Append(item);

            return result.ToString();
        }
    }
}
