using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question266
    {
        public static void EntryPoint()
        {
            (new Question266()).CanPermutePalindrome(string.Empty);
        }

        public bool CanPermutePalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return false;
            else if (s.Length == 1)
                return true;

            Hashtable hash = new Hashtable();
            int singleCharacterCount = 0;

            foreach (var item in s)
                if (hash.Contains(item))
                    hash[item] = (int)hash[item] + 1;
                else
                    hash.Add(item, 1);

            foreach (var item in hash.Values)
                if ((int)item % 2 != 0)
                    if (++singleCharacterCount > 1)
                        return false;

            return true;
        }
    }
}