using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question205
    {
        public static void EntryPoint()
        {
            (new Question205()).IsIsomorphic("egg", "add");
        }

        public bool IsIsomorphic(string s, string t)
        {
            int index = 0;
            Hashtable hashS = new Hashtable();
            Hashtable hashT = new Hashtable();

            while (index <= s.Length - 1)
            {
                if (hashS.ContainsKey(s[index]) != hashT.ContainsKey(t[index]) ||
                    (hashS.ContainsKey(s[index]) && hashT.ContainsKey(t[index]) && (int)hashS[s[index]] != (int)hashT[t[index]]))
                    return false;

                if (!hashS.ContainsKey(s[index]))
                {
                    hashS.Add(s[index], index);
                    hashT.Add(t[index], index);
                }

                index++;
            }

            return true;
        }
    }
}