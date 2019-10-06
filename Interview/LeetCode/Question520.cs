using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question520
    {
        public static void EntryPoint()
        {
            (new Question520()).DetectCapitalUse("");
        }

        public bool DetectCapitalUse(string word)
        {
            if (word == null || word == string.Empty)
                return false;
            else if (word.Length == 1)
                return true;

            bool allowLowerCase = false, allowUpperCase = false;

            if (((int)word[0] >= 97 && (int)word[0] <= 122) ||
                ((int)word[0] >= 65 && (int)word[0] <= 90 && (int)word[1] >= 97 && (int)word[1] <= 122))
                allowLowerCase = true;

            if ((int)word[0] >= 65 && (int)word[0] <= 90 && (int)word[1] >= 65 && (int)word[1] <= 90)
                allowUpperCase = true;

            if ((int)word[0] >= 97 && (int)word[0] <= 122 && (int)word[1] >= 65 && (int)word[1] <= 90)
                return false;

            for (int i = 2; i <= word.Length - 1; i++)
                if (((int)word[i] >= 97 && (int)word[i] <= 122 && !allowLowerCase) ||
                    ((int)word[i] >= 65 && (int)word[i] <= 90 && !allowUpperCase))
                    return false;

            return true;
        }
    }
}