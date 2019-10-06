using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question994
    {
        int[] dr = new int[] { -1, 0, 1, 0 };
        int[] dc = new int[] { 0, -1, 0, 1 };

        public int OrangesRotting(int[][] grid)
        {
            int R = grid.Length,
                C = grid[0].Length,
                code = 0,
                ans = 0;
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> depth = new Dictionary<int, int>();

            for (int r = 0; r < R; ++r)
                for (int c = 0; c < C; ++c)
                    if (grid[r][c] == 2)
                    {
                        code = r * C + c;
                        queue.Enqueue(code);
                        depth.Add(code, 0);
                    }

            while (queue.Count != 0)
            {
                code = queue.Dequeue();
                int r = code / C, 
                    c = code % C;

                for (int k = 0; k < 4; ++k)
                {
                    int nr = r + dr[k];
                    int nc = c + dc[k];

                    if (0 <= nr && nr < R && 0 <= nc && nc < C && grid[nr][nc] == 1)
                    {
                        grid[nr][nc] = 2;

                        int ncode = nr * C + nc;
                        queue.Enqueue(ncode);
                        depth.Add(ncode, depth[code] + 1);

                        ans = depth[ncode];
                    }
                }
            }

            foreach (var row in grid)
                foreach (var v in row)
                    if (v == 1)
                        return -1;

            return ans;
        }
    }
}
