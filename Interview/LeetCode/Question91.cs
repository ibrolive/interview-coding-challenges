using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question91
    {
        public static void EntryPoint()
        {
            (new Question91()).NumDecodings("0");
        }

        public int NumDecodings(string s)
        {
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (Convert.ToInt32(s[i]) - 48 >= 1)
                    count++;

                if (Convert.ToInt32(s[i]) - 48 == 1)
                    count++;

                if (Convert.ToInt32(s[i]) - 48 == 2)
                    if (i + 1 < s.Length && Convert.ToInt32(s[i + 1]) - 48 <= 6)
                        count++;
            }

            return count;
        }
    }
}