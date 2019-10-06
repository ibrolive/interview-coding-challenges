using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.Algorithm.Other
{
    class DijkstraShortestPath
    {
        public static void EntryPoint()
        {
            // Use adjacency list
            // Tuple is graph node. First item is the adjacency node. Second item is the weight between these two nodes.
            List<Tuple<int, int>>[] graph = new List<Tuple<int, int>>[6];

            for (int i = 0; i < 6; i++)
                graph[i] = new List<Tuple<int, int>>();

            graph[0].Add(new Tuple<int, int>(1, 5));
            graph[0].Add(new Tuple<int, int>(3, 9));
            graph[0].Add(new Tuple<int, int>(4, 2));
            graph[1].Add(new Tuple<int, int>(2, 2));
            graph[2].Add(new Tuple<int, int>(3, 3));
            graph[4].Add(new Tuple<int, int>(5, 3));
            graph[5].Add(new Tuple<int, int>(3, 2));

            Dictionary<int, int> result = (new DijkstraShortestPath()).GetShortestPath(graph, 0);

            foreach (var item in result)
                Console.WriteLine(item.Key + " ->" + item.Value);
        }

        public Dictionary<int, int> GetShortestPath(List<Tuple<int, int>>[] graph, int sourceVertex)
        {
            MinHeap<int> minHeap = new MinHeap<int>();
            Dictionary<int, int> distance = new Dictionary<int, int>();

            for (int i = 0; i < graph.Length; i++)
                minHeap.Add(i, Int32.MaxValue);

            minHeap.Decrease(sourceVertex, 0);

            distance.Add(sourceVertex, 0);

            while (minHeap.Count != 0)
            {
                HeapNode<int> curVertex = minHeap.ExtractHeapNode();

                distance[curVertex.Key] = curVertex.Weight;

                foreach (var adjVertex in graph[curVertex.Key])
                {
                    if (!minHeap.Contains(adjVertex.Item1))
                        continue;

                    int newDistance = distance[curVertex.Key] + adjVertex.Item2;

                    if (minHeap[adjVertex.Item1].Weight > newDistance)
                        minHeap.Decrease(adjVertex.Item1, newDistance);
                }
            }

            return distance;
        }
    }
}
