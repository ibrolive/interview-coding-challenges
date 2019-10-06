using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1087
    {
        private List<string> results = new List<string>();

        public string[] Expand(string S)
        {
            Helper(S, 0, new StringBuilder());

            return results.ToArray();
        }

        private void Helper(string S, int i, StringBuilder current)
        {
            if (i == S.Length)
            {
                results.Add(current.ToString());
                return;
            }

            if (S[i] == '{')
            {
                int s = i,
                    e = S.IndexOf('}', i + 1);

                string[] arr = S.Substring(s + 1, s - e - 1).Split(',');
                Array.Sort(arr);

                for (int j = 0; j < arr.Length; j++)
                {
                    StringBuilder temp = new StringBuilder(current.ToString());

                    Helper(S, e + 1, temp.Append(arr[j]));
                }
            }
            else
            {
                current.Append(S[i]);
                Helper(S, i + 1, current);
            }
        }
    }
}
