using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question261
    {
        public static void EntryPoint()
        {
            int[,] input = { { 0, 1 }, { 0, 2 }, { 2, 3 }, { 2, 4 } };
            //int[,] input = { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 1, 3 }, { 1, 4 } };

            (new Question261()).ValidTree(5, input);
        }

        public bool ValidTree(int n, int[,] edges)
        {
            int nodeCount = ValidateTree(0, -1, BuildGraph(n, edges), new bool[n], 0);

            if (nodeCount == -1 || nodeCount != n)
                return false;

            return true;
        }

        private List<int>[] BuildGraph(int nodesVol, int[,] edges)
        {
            List<int>[] graph = new List<int>[nodesVol];

            for (int i = 0; i <= edges.GetLength(0) - 1; i++)
            {
                if (graph[edges[i, 0]] == null)
                    graph[edges[i, 0]] = new List<int>();

                graph[edges[i, 0]].Add(edges[i, 1]);

                if (graph[edges[i, 1]] == null)
                    graph[edges[i, 1]] = new List<int>();

                graph[edges[i, 1]].Add(edges[i, 0]);
            }

            return graph;
        }

        private int ValidateTree(int node, int preNode, List<int>[] graph, bool[] visited, int nodeCount)
        {
            visited[node] = true;
            nodeCount++;

            if (graph[node] != null)
            {
                foreach (var neighbor in graph[node])
                    if (!visited[neighbor])
                        nodeCount += ValidateTree(neighbor, node, graph, visited, 0);
                    else if (visited[neighbor] && neighbor != preNode)
                        return -1;
            }

            return nodeCount;
        }
    }
}