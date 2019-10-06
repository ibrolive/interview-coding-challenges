using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1156
    {
        public static void EntryPoint()
        {
            //(new Question1156()).MaxRepOpt1("aabaaabaaaba");
            //(new Question1156()).MaxRepOpt1("aaaaa");
            //(new Question1156()).MaxRepOpt1("bbababaaaa");
            //(new Question1156()).MaxRepOpt1("aaabaaa");
            //(new Question1156()).MaxRepOpt1("babbaaabbbbbaa");
            (new Question1156()).MaxRepOpt1("baaabaaaaaaabaab");
        }

        public int MaxRepOpt1(string text)
        {
            int result = Int32.MinValue;
            Dictionary<char, List<int>> dict = new Dictionary<char, List<int>>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!dict.ContainsKey(text[i]))
                    dict.Add(text[i], new List<int>());

                dict[text[i]].Add(i);
            }

            foreach (var item in dict.Values)
            {
                int s = item[0];

                for (int i = 0; i < item.Count - 1; i++)
                {
                    if (item[i + 1] - item[i] > 2)
                    {
                        result = Math.Max(result, item[i] - s + 2);
                        s = item[i + 1];
                    }
                    else if (item[i + 1] - item[i] == 2)
                    {
                        int j = i + 1;

                        while (j < item.Count - 1 && item[j + 1] - item[j] == 1)
                            j++;

                        result = Math.Max(result, s == item[0] && j == item.Count - 1 ? item[j] - s : item[j] - s + 1);
                        s = item[i + 1];
                    }
                }

                if (s == item[0])
                    result = Math.Max(result, item.Count);

                if (s != item[0] && item[item.Count - 1] != text.Length - 1)
                    result = Math.Max(result, item[item.Count - 1] - s + 1);
            }

            return result;
        }
    }
}
