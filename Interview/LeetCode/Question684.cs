using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question684
    {
        public static void EntryPoint()
        {
            //int[,] edges = { { 9, 10 }, { 5, 8 }, { 2, 6 }, { 1, 5 }, { 3, 8 }, { 4, 9 }, { 8, 10 }, { 4, 10 }, { 6, 8 }, { 7, 9 } };
            int[,] edges = { { 1, 2 }, { 1, 3 }, { 2, 3 } };
            //int[,] edges = { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 1, 4 }, { 1, 5 } };

            (new Question684()).FindRedundantConnection2(edges);
        }

        // DFS solution
        public int[] FindRedundantConnection1(int[,] edges)
        {
            List<int>[] graph = new List<int>[edges.GetLength(0) + 1];
            int[] visited = null,
                  result = new int[2];

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                visited = new int[edges.GetLength(0) + 1];

                if (DFS(graph, visited, edges[i, 0], edges[i, 1]))
                {
                    result[0] = edges[i, 0];
                    result[1] = edges[i, 1];

                    return result;
                }
                else
                {
                    if (graph[edges[i, 0]] == null)
                        graph[edges[i, 0]] = new List<int>();

                    if (graph[edges[i, 1]] == null)
                        graph[edges[i, 1]] = new List<int>();

                    graph[edges[i, 0]].Add(edges[i, 1]);
                    graph[edges[i, 1]].Add(edges[i, 0]);
                }
            }

            return result;
        }

        private bool DFS(List<int>[] graph, int[] visited, int currentNode, int targetNode)
        {
            if (currentNode == targetNode)
                return true;
            else if (visited[currentNode] == 1)
                return false;

            visited[currentNode] = 1;

            if (graph[currentNode] != null)
                for (int i = 0; i < graph[currentNode].Count; i++)
                    if (DFS(graph, visited, graph[currentNode][i], targetNode))
                        return true;

            return false;
        }

        // Disjoint-set
        public int[] FindRedundantConnection2(int[,] edges)
        {
            DisjointSet set = new DisjointSet(edges.Length + 1);

            for (int i = 0; i < edges.GetLength(0); i++)
                if (!set.Union(edges[i, 0], edges[i, 1]))
                    return new int[] { edges[i, 0], edges[i, 1] };

            return null;
        }

        class DisjointSet
        {
            int[] parent = null;
            int[] rank = null;

            public DisjointSet(int capacity)
            {
                parent = new int[capacity];
                rank = new int[capacity];
            }

            public bool Union(int node1, int node2)
            {
                int parentNode1 = Find(node1),
                    parentNode2 = Find(node2);

                if (parentNode1 != 0 && parentNode1 == parentNode2)
                    return false;

                if (rank[parentNode1] >= rank[parentNode2])
                {
                    parent[parentNode2] = parentNode1;
                    rank[parentNode1] += 1;
                }
                else
                {
                    parent[parentNode1] = parentNode2;
                    rank[parentNode2] += 1;
                }

                return true;
            }

            public int Find(int node)
            {
                if (parent[node] == 0)
                    return node;

                return parent[node] = Find(parent[node]);
            }
        }
    }
}
