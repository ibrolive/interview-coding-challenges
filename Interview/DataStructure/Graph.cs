using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.DataStructure
{
    class GraphTest
    {
        public static void EntryPoint()
        {
            Graph graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(3, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 2);
            graph.AddEdge(0, 4);
            graph.AddEdge(4, 0);

            graph.BFS();
        }
    }

    // Reference:
    // https://www.khanacademy.org/computing/computer-science/algorithms/graph-representation/a/representing-graphs
    class Graph
    {
        int[,] vertices = null;

        public Graph(int verticeCount)
        {
            vertices = new int[verticeCount, verticeCount];
        }

        public void AddEdge(int start, int end)
        {
            vertices[start, end] = 1;
        }

        // Refer:
        // http://www.geeksforgeeks.org/depth-first-traversal-for-a-graph/
        // https://segmentfault.com/a/1190000002685782#articleHeader2
        // https://segmentfault.com/a/1190000002685939
        public void DFS()
        {
            DFSUtil(vertices[0, 0], new bool[vertices.GetLength(0)]);
        }

        private void DFSUtil(int currentVertice, bool[] isVisited)
        {
            Console.WriteLine(currentVertice);
            isVisited[currentVertice] = true;

            List<int> adjacencyVertices = GetAllAdjacencyVertice(currentVertice);

            foreach (var item in adjacencyVertices)
                if (!isVisited[item])
                    DFSUtil(item, isVisited);
        }

        public void BFS()
        {

        }

        public bool HasCycle()
        {
            return false;
        }

        public int GetAdjacencyVertice(int currentVertice)
        {
            for (int i = 0; i <= vertices.GetLength(1) - 1; i++)
                if (vertices[currentVertice, i] != 0)
                    return i;

            return -1;
        }

        public List<int> GetAllAdjacencyVertice(int currentVertice)
        {
            List<int> adjacencyVertices = new List<int>();

            for (int i = 0; i <= vertices.GetLength(0) - 1; i++)
                if (vertices[currentVertice, i] != 0)
                    adjacencyVertices.Add(i);

            return adjacencyVertices;
        }
    }
}