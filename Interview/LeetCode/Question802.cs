using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question802
    {
        // https://leetcode.com/problems/find-eventual-safe-states/solution/
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int N = graph.Length;
            int[] color = new int[N];
            List<int> ans = new List<int>();

            for (int i = 0; i < N; ++i)
                if (dfs(i, color, graph))
                    ans.Add(i);

            return ans;
        }

        public bool dfs(int node, int[] color, int[][] graph)
        {
            if (color[node] > 0)
                return color[node] == 2;

            color[node] = 1;

            foreach (var nei in graph[node])
            {
                if (color[node] == 2)
                    continue;
                if (color[nei] == 1 || !dfs(nei, color, graph))
                    return false;
            }

            color[node] = 2;

            return true;
        }
    }
}
