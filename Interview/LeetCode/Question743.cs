using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question743
    {
        public static void EntryPoint()
        {
            int[][] times = new int[3][];
            times[0] = new int[] { 1, 2, 1 };
            times[1] = new int[] { 2, 3, 2 };
            times[2] = new int[] { 1, 3, 2 };

            (new Question743()).NetworkDelayTime(times, 3, 1);
        }

        // https://leetcode.com/problems/network-delay-time/solution/

        Dictionary<int, int> dist = new Dictionary<int, int>();

        public int NetworkDelayTime(int[][] times, int N, int K)
        {
            int ans = 0;
            Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();

            foreach (var edge in times)
            {
                if (!graph.Keys.Contains(edge[0]))
                    graph.Add(edge[0], new List<int[]>());

                graph[edge[0]].Add(new int[] { edge[2], edge[1] });
            }

            for (int node = 1; node <= N; ++node)
                dist.Add(node, Int32.MaxValue);

            dfs(graph, K, 0);

            foreach (var cand in dist.Values)
            {
                if (cand == Int32.MaxValue)
                    return -1;

                ans = Math.Max(ans, cand);
            }

            return ans;
        }

        public void dfs(Dictionary<int, List<int[]>> graph, int node, int elapsed)
        {
            if (elapsed >= dist[node])
                return;

            dist[node] = elapsed;

            if (graph.Keys.Contains(node))
                foreach (var info in graph[node])
                    dfs(graph, info[1], elapsed + info[0]);
        }
    }
}
