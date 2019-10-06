using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question399
    {
        public static void EntryPoint()
        {
            (new Question399()).CalcEquation(new string[,] { { "a", "b" }, { "b", "c" } },
                                             new double[] { 2.0, 3.0 },
                                             new string[,] { { "a", "c" }, { "b", "c" }, { "a", "e" }, { "a", "a" }, { "x", "x" } });
        }

        // https://leetcode.com/problems/evaluate-division/discuss/171649/1ms-DFS-with-Explanations
        public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
        {
            double[] result = new double[queries.GetLength(0)];
            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < equations.GetLength(0); i++)
            {
                if (!graph.ContainsKey(equations[i, 0]))
                    graph.Add(equations[i, 0], new Dictionary<string, double>());

                graph[equations[i, 0]].Add(equations[i, 1], values[i]);

                if (!graph.ContainsKey(equations[i, 1]))
                    graph.Add(equations[i, 1], new Dictionary<string, double>());

                graph[equations[i, 1]].Add(equations[i, 0], 1 / values[i]);
            }

            for (int i = 0; i < queries.GetLength(0); i++)
                result[i] = Helper(graph, queries[i, 0], 1, queries[i, 1], new List<string>());

            return result;
        }

        private double Helper(Dictionary<string, Dictionary<string, double>> graph, string currentNode, double currentValue, string destination, List<string> visited)
        {
            double temp = 0;

            if (graph.ContainsKey(currentNode))
                foreach (var item in graph[currentNode])
                {
                    if (item.Key == destination)
                        return currentValue * item.Value;

                    if (!visited.Contains(item.Key))
                    {
                        visited.Add(item.Key);

                        temp = Helper(graph, item.Key, currentValue * item.Value, destination, visited);

                        if (temp != -1.0)
                            return temp;
                    }
                }

            return -1.0;
        }
    }
}
