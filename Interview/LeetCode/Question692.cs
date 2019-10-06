using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question692
    {
        public static void EntryPoint()
        {
            (new Question692()).TopKFrequent(new string[] { "i", "love", "leetcode", "i", "love", "coding" }, 2);
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {
            List<string> result = new List<string>();
            Hashtable tempHash = new Hashtable();
            List<string>[] tempArray = null;
            int max = 0,
                currentIndex = 0;

            foreach (var item in words)
            {
                if (!tempHash.ContainsKey(item))
                    tempHash.Add(item, 0);

                tempHash[item] = (int)tempHash[item] + 1;

                if ((int)tempHash[item] > max)
                    max = (int)tempHash[item];
            }

            tempArray = new List<string>[max + 1];

            foreach (var item in tempHash.Keys)
            {
                if (tempArray[(int)tempHash[item]] == null)
                    tempArray[(int)tempHash[item]] = new List<string>();

                tempArray[(int)tempHash[item]].Add((string)item);
            }

            foreach (var item in tempArray)
                if (item != null)
                    item.Sort();

            for (int i = max; i >= 0; i--)
            {
                if (currentIndex >= k)
                    break;

                if (tempArray[i] != null)
                {
                    foreach (var item in tempArray[i])
                    {
                        if (currentIndex >= k)
                            break;

                        result.Add(item);
                        currentIndex++;
                    }
                }
            }

            return result;
        }
    }
}
