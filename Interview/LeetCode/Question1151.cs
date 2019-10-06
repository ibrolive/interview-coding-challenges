using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1151
    {
        public static void EntryPoint()
        {
            //(new Question1151()).MinSwaps(new int[] { 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1 });
            (new Question1151()).MinSwaps(new int[] { 1, 0, 1, 0, 1 });
        }

        public int MinSwaps(int[] data)
        {
            int ones = 0,
                window = 0;

            for (int i = 0; i < data.Length; i++)
                if (data[i] == 1)
                    ones++;

            for (int i = 0; i < ones; i++)
                if (data[i] == 1)
                    window++;

            int max = window;
            for (int i = ones; i < data.Length; i++)
            {
                window += data[i];
                window -= data[i - ones];
                max = Math.Max(max, window);
            }

            return ones - max;
        }
    }
}
