using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question738
    {
        public static void EntryPoint()
        {
            (new Question738()).MonotoneIncreasingDigits(0);
        }

        public int MonotoneIncreasingDigits(int N)
        {
            int result = 0,
                boudary = -1;
            List<int> list = new List<int>();

            while (N != 0)
            {
                list.Add(N % 10);
                N = N / 10;
            }

            for (int i = 0; i < list.Count - 1; i++)
                if (list[i] < list[i + 1])
                {
                    list[i + 1] = list[i + 1] - 1;
                    boudary = i + 1;
                }

            for (int i = boudary; i >= 0; i--)
                list[i] = 9;

            for (int i = 0; i < list.Count; i++)
                result += list[i] * (int)Math.Pow(10, i);

            return result;
        }
    }
}
