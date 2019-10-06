using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Interview.LeetCode
{
    class Question49
    {
        public static void EntryPoint()
        {
            string[] input = { "eat", "tea", "tan", "ate", "nat", "bat" };

            (new Question49()).GroupAnagrams(input);
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return null;

            List<IList<string>> result = new List<IList<string>>();
            List<string> temp = null;
            Hashtable dictionary = new Hashtable();
            int currentIndex = 0;

            if (strs.Length == 1)
            {
                temp = new List<string>();
                temp.Add(strs[0]);
                result.Add(temp);

                return result;
            }

            foreach (var item in strs)
            {
                if (dictionary.Contains(SortString(item)))
                    result[(int)dictionary[SortString(item)]].Add(item);
                else
                {
                    dictionary.Add(SortString(item), currentIndex++);

                    temp = new List<string>();
                    temp.Add(item);
                    result.Add(temp);
                }
            }

            return result;
        }

        public static string SortString(string input)
        {
            char[] output = input.ToArray();
            Array.Sort(output);

            return new string(output);
        }
    }
}