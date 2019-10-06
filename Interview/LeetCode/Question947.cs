using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question947
    {
        public static void EntryPoint()
        {
            //int[][] input = new int[6][];

            //input[0] = new int[] { 0, 0 };
            //input[1] = new int[] { 0, 1 };
            //input[2] = new int[] { 1, 0 };
            //input[3] = new int[] { 1, 2 };
            //input[4] = new int[] { 2, 1 };
            //input[5] = new int[] { 2, 2 };

            int[][] input = new int[3][];

            input[0] = new int[] { 1, 1 };
            input[1] = new int[] { 1, 2 };
            input[2] = new int[] { 3, 1 };

            (new Question947()).removeStones(input);
        }

        // https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/discuss/239162/DFS-Time-O(N)-Space-O(N)-ConciseandandReadable
        // https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/solution/
        public int removeStones(int[][] stones)
        {
            DSU dsu = new DSU(20000);
            HashSet<int> seen = new HashSet<int>();

            foreach (var stone in stones)
                dsu.union(stone[0], stone[1] + 10000);

            foreach (var stone in stones)
                seen.Add(dsu.find(stone[0]));

            return stones.Length - seen.Count();
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
