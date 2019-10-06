using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question785
    {
        public static void EntryPoint()
        {
            int[][] graph = new int[4][];
            graph[0] = new int[] { 1, 2, 3 };
            graph[1] = new int[] { 0, 2 };
            graph[2] = new int[] { 0, 1, 3 };
            graph[3] = new int[] { 0, 2 };

            (new Question785()).IsBipartite(graph);
        }

        // https://leetcode.com/problems/is-graph-bipartite/solution/
        public bool IsBipartite(int[][] graph)
        {
            int n = graph.Length,
                node = 0;
            int[] color = Enumerable.Repeat(-1, n).ToArray();
            Stack<int> stack = null;

            for (int start = 0; start < n; start++)
                if (color[start] == -1)
                {
                    stack = new Stack<int>();

                    stack.Push(start);
                    color[start] = 0;

                    while (stack.Any())
                    {
                        node = stack.Pop();

                        foreach (var nei in graph[node])
                            if (color[nei] == -1)
                            {
                                stack.Push(nei);
                                color[nei] = color[node] ^ 1;
                            }
                            else if (color[nei] == color[node])
                                return false;
                    }
                }

            return true;
        }
    }
}
