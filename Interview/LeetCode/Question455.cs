using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question455
    {
        public static void EntryPoint()
        {
            (new Question455()).FindContentChildren(new int[] { 10,9,8,7 }, new int[] { 5,6,7,8 });
        }

        public int FindContentChildren(int[] g, int[] s)
        {
            if (g == null || g.Length == 0 || s == null || s.Length == 0)
                return 0;

            int i, j;

            Array.Sort(g);
            Array.Sort(s);

            for (i = 0, j = 0; i <= g.Length - 1 && j <= s.Length - 1; j++)
                if (g[i] <= s[j])
                    i++;

            return i;
        }
    }
}