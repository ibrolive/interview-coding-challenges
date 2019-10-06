using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question434
    {
        public int CountSegments(string s)
        {
            if (s == null || s == string.Empty)
                return 0;

            int count = 0;
            string trimmedString = s.Trim();

            if (trimmedString == string.Empty)
                return 0;

            for (int index = 1; index <= trimmedString.Length - 1; index++)
                if ((int)trimmedString[index] == 32 && (int)trimmedString[index - 1] != 32)
                    count++;

            return ++count;
        }
    }
}