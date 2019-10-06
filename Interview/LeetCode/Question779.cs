using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question779
    {
        public static void EntryPoint()
        {
            (new Question779()).KthGrammar(3, 1);
        }

        public int KthGrammar(int N, int K)
        {
            int[] lastrow = new int[1 << N];

            for (int i = 1; i < N; ++i)
                for (int j = (1 << (i - 1)) - 1; j >= 0; --j)
                {
                    lastrow[2 * j] = lastrow[j];
                    lastrow[2 * j + 1] = 1 - lastrow[j];
                }

            return lastrow[K - 1];
        }
    }
}
