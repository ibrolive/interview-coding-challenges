using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question393
    {
        public static void EntryPoint()
        {
            (new Question393()).ValidUtf8(new int[] { 197, 130, 1 });
        }

        // https://leetcode.com/problems/utf-8-validation/description/
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/byte
        public bool ValidUtf8(int[] data)
        {
            int count = 0;

            foreach (var item in data)
            {
                if (item < 128)
                    continue;

                if (count == 0)
                {
                    if ((item >> 5) == 0b110)
                        count = 1;
                    else if ((item >> 4) == 0b1110)
                        count = 2;
                    else if ((item >> 3) == 0b11110)
                        count = 3;
                    else
                        return false;
                }
                else
                {
                    if ((item >> 6) != 0b10)
                        return false;
                    else
                        count--;
                }
            }

            return count == 0;
        }
    }
}
