using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question844
    {
        public static void EntryPoint()
        {
            (new Question844()).BackspaceCompare("ab##", "c#d#");
        }

        public bool BackspaceCompare(string S, string T)
        {
            int indexS = S.Length - 1,
                indexT = T.Length - 1,
                deleteCountS = 0,
                deleteCountT = 0;

            char charS = '\0',
                 charT = '\0';

            while (indexS >= 0 || indexT >= 0)
            {
                charS = indexS >= 0 ? S[indexS] : '0';
                charT = indexT >= 0 ? T[indexT] : '0';

                if (charS == '#')
                {
                    deleteCountS++;
                    indexS--;
                }
                else if (charT == '#')
                {
                    deleteCountT++;
                    indexT--;
                }
                else if (deleteCountS > 0)
                {
                    deleteCountS--;
                    indexS--;
                }
                else if (deleteCountT > 0)
                {
                    deleteCountT--;
                    indexT--;
                }
                else if (charS == charT)
                {
                    indexS--;
                    indexT--;
                }
                else if (charS != charT)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
