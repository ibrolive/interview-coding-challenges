using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question279
    {
        public static void EntryPoint()
        {
            (new Question279()).NumSquares(12);
        }

        public int NumSquares(int n)
        {
            int remainNumber = 0,
                currentResult = 0;
            int[] results = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                remainNumber = i;
                currentResult = Int32.MaxValue;

                for (int j = 1; j * j <= remainNumber; j++)
                    currentResult = Math.Min(currentResult, results[remainNumber - j * j] + 1);

                results[i] = currentResult;
            }

            return results[n];
        }
    }
}
