using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question242
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            char[] source = s.ToCharArray(), target = t.ToCharArray();

            Array.Sort(source);
            Array.Sort(target);

            for (int i = 0; i <= source.Length - 1; i++)
                if (source[i] != target[i])
                    return false;

            return true;
        }
    }
}