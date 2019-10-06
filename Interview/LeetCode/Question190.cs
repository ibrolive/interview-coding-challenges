using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question190
    {
        public static void EntryPoint()
        {
            (new Question190()).reverseBits(5);
        }

        public uint reverseBits(uint n)
        {
            uint reverse = 0;

            for (int i = 1; i <= 32; i++)
            {
                reverse <<= 1;

                if ((n & 1) == 1)
                    reverse ^= 1;

                n >>= 1;
            }

            return reverse;
        }
    }
}
