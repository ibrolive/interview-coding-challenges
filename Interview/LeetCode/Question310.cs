using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question310
    {
        // https://leetcode.com/problems/minimum-height-trees/discuss/76138/Java-layer-by-layer-BFS
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (edges == null || edges.GetLength(0) == 0 || edges.GetLength(1) == 0)
                return new List<int>();

            if (n == 1)
                return new List<int> { 0 };

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Queue<int> leaf = null;
            int node = 0,
                temp = 0;

            for (int i = 0; i < edges.Length; i++)
            {
                if (!graph.ContainsKey(edges[i][0]))
                    graph.Add(edges[i][0], new List<int>());

                graph[edges[i][0]].Add(edges[i][1]);

                if (!graph.ContainsKey(edges[i][1]))
                    graph.Add(edges[i][1], new List<int>());

                graph[edges[i][1]].Add(edges[i][0]);
            }

            leaf = new Queue<int>(graph.Where(d => d.Value.Count == 1).Select(item => item.Key));

            while (graph.Count > 2)
            {
                var nl = new Queue<int>();

                while (leaf.Any())
                {
                    node = leaf.Dequeue();
                    temp = graph[node][0];

                    graph.Remove(node);
                    graph[temp].Remove(node);

                    if (graph[temp].Count == 1)
                        nl.Enqueue(temp);
                }

                leaf = nl;
            }

            return leaf.ToList();
        }
    }
}
