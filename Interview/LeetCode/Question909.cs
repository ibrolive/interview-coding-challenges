using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question909
    {
        // https://leetcode.com/problems/snakes-and-ladders/solution/
        public int SnakesAndLadders(int[][] board)
        {
            int N = board.Length;
            Dictionary<int, int> dist = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();

            dist.Add(1, 0);
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                int s = queue.Dequeue();

                if (s == N * N)
                    return dist[s];

                for (int s2 = s + 1; s2 <= Math.Min(s + 6, N * N); s2++)
                {
                    int rc = get(s2, N),
                        r = rc / N,
                        c = rc % N,
                        s2Final = board[r][c] == -1 ? s2 : board[r][c];

                    if (!dist.ContainsKey(s2Final))
                    {
                        dist[s2Final] = dist[s] + 1;
                        queue.Enqueue(s2Final);
                    }
                }
            }

            return -1;
        }

        private int get(int s, int N)
        {
            int quot = (s - 1) / N,
                rem = (s - 1) % N,
                row = N - 1 - quot,
                col = row % 2 != N % 2 ? rem : N - 1 - rem;

            return row * N + col;
        }
    }
}
