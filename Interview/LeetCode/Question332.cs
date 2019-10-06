using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question332
    {
        public static void EntryPoint()
        {
            //string[,] input = { { "MUC", "LHR" }, { "JFK", "MUC" }, { "SFO", "SJC" }, { "LHR", "SFO" } };
            //string[,] input = { { "JFK", "KUL" }, { "JFK", "NRT" }, { "NRT", "JFK" } };
            //string[,] input = { { "JFK", "SFO" }, { "JFK", "ATL" }, { "SFO", "ATL" }, { "ATL", "JFK" }, { "ATL", "SFO" } };
            string[,] input = { { "EZE", "TIA" }, { "EZE","HBA" }, {"AXA","TIA" },{"JFK","AXA"},{"ANU","JFK"},{"ADL","ANU"},{"TIA","AUA"},{"ANU","AUA"},{"ADL","EZE"},{"ADL","EZE"},{"EZE","ADL"},{"AXA","EZE"},{"AUA","AXA"},{"JFK","AXA"},{"AXA","AUA"},{"AUA","ADL"},{"ANU","EZE"},{"TIA","ADL"},{"EZE","ANU"},{"AUA","ANU"} };

            (new Question332()).FindItinerary(input);
        }

        public IList<string> FindItinerary(string[,] tickets)
        {
            List<string> result = new List<string>();
            Stack<string> resultInStack = new Stack<string>();
            Hashtable graph = new Hashtable();

            for (int i = 0; i <= tickets.GetLength(0) - 1; i++)
            {
                if (!graph.Contains(tickets[i, 0]))
                    graph.Add(tickets[i, 0], new List<string>());

                ((List<string>)graph[tickets[i, 0]]).Add(tickets[i, 1]);
            }

            foreach (var item in graph.Values)
                ((List<string>)item).Sort();

            DFS("JFK", graph, resultInStack);

            while (resultInStack.Count != 0)
                result.Add(resultInStack.Pop());

            return result;
        }

        private void DFS(string currentStation, Hashtable graph, Stack<string> resultInStack)
        {
            string tempStation = string.Empty;

            while (graph.Contains(currentStation) && ((List<string>)graph[currentStation]).Count != 0)
            {
                tempStation = ((List<string>)graph[currentStation])[0];
                ((List<string>)graph[currentStation]).RemoveAt(0);
                DFS(tempStation, graph, resultInStack);
            }

            resultInStack.Push(currentStation);
        }
    }
}