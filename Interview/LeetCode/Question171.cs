using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question171
    {
        public static void EntryPoint()
        {
            (new Question171()).TitleToNumber("A");
        }

        public int TitleToNumber(string s)
        {
            int index = 0, count = s.Length - 1, result = 0;

            while (count >= 0)
                result += ((int)s[index++] - 64) * (int)Math.Pow(26, count--);

            return result;
        }
    }
}