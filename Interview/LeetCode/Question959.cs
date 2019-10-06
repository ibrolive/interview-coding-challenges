using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question959
    {
        // https://leetcode.com/problems/regions-cut-by-slashes/solution/
        public int RegionsBySlashes(string[] grid)
        {
            int N = grid.Length;
            DSU dsu = new DSU(4 * N * N);

            for (int r = 0; r < N; ++r)
                for (int c = 0; c < N; ++c)
                {
                    int root = 4 * (r * N + c);
                    char val = grid[r][c];

                    if (val != '\\')
                    {
                        dsu.union(root + 0, root + 1);
                        dsu.union(root + 2, root + 3);
                    }

                    if (val != '/')
                    {
                        dsu.union(root + 0, root + 2);
                        dsu.union(root + 1, root + 3);
                    }

                    if (r + 1 < N)
                        dsu.union(root + 3, (root + 4 * N) + 0);

                    if (r - 1 >= 0)
                        dsu.union(root + 0, (root - 4 * N) + 3);

                    if (c + 1 < N)
                        dsu.union(root + 2, (root + 4) + 1);

                    if (c - 1 >= 0)
                        dsu.union(root + 1, (root - 4) + 2);
                }

            int ans = 0;

            for (int x = 0; x < 4 * N * N; ++x)
                if (dsu.find(x) == x)
                    ans++;

            return ans;
        }

        class DSU
        {
            int[] parent;

            public DSU(int N)
            {
                parent = new int[N];

                for (int i = 0; i < N; ++i)
                    parent[i] = i;
            }
            public int find(int x)
            {
                if (parent[x] != x)
                    parent[x] = find(parent[x]);

                return parent[x];
            }
            public void union(int x, int y)
            {
                parent[find(x)] = find(y);
            }
        }
    }
}
