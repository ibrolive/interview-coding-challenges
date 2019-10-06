using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question526
    {
        public static void EntryPoint()
        {
            (new Question526()).CountArrangement(2);
        }

        private int _count = 0;

        public int CountArrangement(int N)
        {
            Helper(1, N, new bool[N]);

            return _count;
        }

        private void Helper(int i, int N, bool[] visited)
        {
            if (i > N)
            {
                this._count++;

                return;
            }

            for (int j = 1; j <= N; j++)
            {
                if (!visited[j - 1] && (i % j == 0 || j % i == 0))
                {
                    visited[j - 1] = true;

                    Helper(i + 1, N, visited);

                    visited[j - 1] = false;
                }
            }
        }
    }
}
