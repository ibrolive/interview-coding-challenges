using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question131
    {
        public static void EntryPoint()
        {
            (new Question131()).Partition("aab");
        }

        public IList<IList<string>> Partition(string s)
        {
            if (s == null || s == string.Empty)
                return null;

            IList<IList<string>> result = new List<IList<string>>();

            for (int i = 0; i < s.Length; i++)
                DFS(s, 0, i, new List<string>(), result);

            return result;
        }

        private void DFS(string s, int start, int end, List<string> currentPartitions, IList<IList<string>> result)
        {
            List<string> temp = null;

            if (CheckPalindrome(s.Substring(start, end - start + 1)))
            {
                currentPartitions.Add(s.Substring(start, end - start + 1));

                if (end == s.Length - 1)
                    result.Add(currentPartitions);
                else
                {
                    for (int i = end + 1; i < s.Length; i++)
                    {
                        temp = new List<string>();
                        foreach (var item in currentPartitions)
                            temp.Add(item);

                        DFS(s, end + 1, i, temp, result);
                    }
                }
            }
        }

        private bool CheckPalindrome(string partition)
        {
            int start = 0,
                end = partition.Length - 1;

            while (start < end)
                if (partition[start++] != partition[end--])
                    return false;

            return true;
        }
    }
}
