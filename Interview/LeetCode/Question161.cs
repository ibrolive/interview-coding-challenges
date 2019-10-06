using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question161
    {
        public static void EntryPoint()
        {
            (new Question161()).IsOneEditDistance("teacher", "tache");
        }

        public bool IsOneEditDistance(string s, string t)
        {
            if ((s.Length == 0 && t.Length == 0) || s == t)
                return false;

            if ((s.Length == 1 && t.Length == 0) || (s.Length == 0 && t.Length == 1))
                return true;

            int indexS = 0,
                indexT = 0,
                differenceCount = 0;

            while (indexS < s.Length && indexT < t.Length)
            {
                if (s[indexS] != t[indexT] && differenceCount != 0)
                    return false;
                else if (s[indexS] != t[indexT])
                {
                    differenceCount = 1;

                    if (s.Length > t.Length)
                    {
                        s = s.Remove(indexS, 1);

                        indexS--;
                        indexT--;
                    }
                    else if (s.Length < t.Length)
                    {
                        t = t.Remove(indexT, 1);

                        indexS--;
                        indexT--;
                    }
                }

                indexS++;
                indexT++;
            }

            if (Math.Abs(s.Length - t.Length) > 1 || (Math.Abs(s.Length - t.Length) == 1 && differenceCount == 1))
                return false;

            return true;
        }
    }
}
