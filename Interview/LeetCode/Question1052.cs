using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question1052
    {
        public static void EntryPoint()
        {
            (new Question1052()).MaxSatisfied(new int[] { 1, 0, 1, 2, 1, 1, 7, 5 }, new int[] { 0, 1, 0, 1, 0, 1, 0, 1 }, 3);
        }

        public int MaxSatisfied(int[] customers, int[] grumpy, int X)
        {
            int satisfy = 0;
            int maxSatisfy = 0;
            int extraSatisfy = 0;

            for (int i = 0; i < grumpy.Length; i++)
            {
                if (grumpy[i] == 0)
                    satisfy += customers[i];
                else
                    extraSatisfy += customers[i];

                if (i >= X && grumpy[i - X] == 1)
                    extraSatisfy -= customers[i - X];

                maxSatisfy = Math.Max(maxSatisfy, extraSatisfy);
            }

            return satisfy + maxSatisfy;
        }
    }
}
