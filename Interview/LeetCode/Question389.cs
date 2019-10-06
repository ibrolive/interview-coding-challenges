using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question389
    {
        public static void EntryPoint()
        {
            (new Question389()).FindTheDifference("abcd", "abcde");
        }

        public char FindTheDifference(string s, string t)
        {
            Hashtable hashTableS = new Hashtable();
            Hashtable hashTableT = new Hashtable();

            foreach (var item in s)
                if (!hashTableS.ContainsKey(item))
                    hashTableS.Add(item, 1);
                else
                    hashTableS[item] = ((int)hashTableS[item]) + 1;

            foreach (var item in t)
                if (!hashTableT.ContainsKey(item))
                    hashTableT.Add(item, 1);
                else
                    hashTableT[item] = ((int)hashTableT[item]) + 1;

            foreach (var item in hashTableT.Keys)
                if (!hashTableS.Contains(item) || (int)hashTableS[item] != (int)hashTableT[item])
                    return (char)item;

            return new char();
        }
    }
}