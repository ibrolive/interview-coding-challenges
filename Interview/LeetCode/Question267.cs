using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question267
    {
        public static void EntryPoint()
        {
            (new Question267()).GeneratePalindromes("aabb");
        }

        public IList<string> GeneratePalindromes(string s)
        {
            IList<string> result = new List<string>();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            StringBuilder temp = new StringBuilder();
            char middle = '\0';

            foreach (var item in s)
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, 1);
                else
                    dictionary[item] = (int)dictionary[item] + 1;

            foreach (var item in dictionary.Keys)
                if ((int)dictionary[item] % 2 != 0 && middle != '\0')
                    return new List<string>();
                else if ((int)dictionary[item] % 2 != 0)
                    middle = (char)item;

            if (dictionary.Keys.Count == 1)
            {
                result.Add(s);

                return result;
            }

            foreach (var item in dictionary.Keys)
                if (dictionary[item] != 0)
                    for (int i = 0; i < dictionary[item] / 2; i++)
                        temp.Append(item);

            Helper(temp, new StringBuilder(), middle, result);

            return result;
        }

        private void Helper(StringBuilder source, StringBuilder previous, char middle, IList<string> result)
        {
            if (source.Length == 0)
            {
                int leftLength = previous.Length - 1;

                if (middle != '\0')
                    previous.Append(middle);

                for (int i = leftLength; i >= 0; i--)
                    previous.Append(previous[i]);

                result.Add(previous.ToString());

                return;
            }

            for (int i = 0; i < source.Length; i++)
                if (i == 0 || (i != 0 && source[i - 1] != source[i]))
                    Helper(new StringBuilder(source.ToString()).Remove(i, 1),
                           new StringBuilder(previous.ToString()).Append(source[i]),
                           middle,
                           result);
        }
    }
}
