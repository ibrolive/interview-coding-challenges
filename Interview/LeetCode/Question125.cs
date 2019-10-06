using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question125
    {
        public static void EntryPoint()
        {
            (new Question125()).IsPalindrome("0P");
        }

        public bool IsPalindrome(string s)
        {
            if (s == null)
                return false;

            string lowerVersion = s.ToLower().Trim();
            int i = 0, j = lowerVersion.Length - 1;

            while (i < j)
            {
                while (i <= lowerVersion.Length - 1 && 
                       (((int)lowerVersion[i] < 48 || (int)lowerVersion[i] > 57) && ((int)lowerVersion[i] < 97 || (int)lowerVersion[i] > 122)))
                    i++;

                while (j >= 0 && 
                       (((int)lowerVersion[j] < 48 || (int)lowerVersion[j] > 57) && ((int)lowerVersion[j] < 97 || (int)lowerVersion[j] > 122)))
                    j--;

                if (i > lowerVersion.Length - 1 || j < 0)
                    break;

                if (lowerVersion[i++] != lowerVersion[j--])
                    return false;
            }

            return true;
        }
    }
}