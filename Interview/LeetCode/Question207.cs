using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question207
    {
        public static void EntryPoint()
        {
            (new Question207()).CanFinish(2, new int[1, 2] { { 1, 0 } });
        }

        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            if (prerequisites.GetLength(0) == 0)
                return true;

            bool[] visited = new bool[numCourses];
            List<int>[] graph = new List<int>[numCourses];

            for (int i = 0; i <= numCourses - 1; i++)
                graph[i] = new List<int>();

            for (int i = 0; i <= prerequisites.GetLength(0) - 1; i++)
                graph[prerequisites[i, 0]].Add(prerequisites[i, 1]);

            for (int i = 0; i <= graph.Length - 1; i++)
                if (!visited[i])
                    if (!DFS(graph, visited, new bool[numCourses], i))
                        return false;

            return true;
        }

        private bool DFS(List<int>[] graph, bool[] visited, bool[] currentPath, int course)
        {
            if (currentPath[course])
                return false;

            visited[course] = true;
            currentPath[course] = true;

            for (int i = 0; i < graph[course].Count; i++)
                if (!DFS(graph, visited, currentPath, graph[course][i]))
                    return false;

            currentPath[course] = false;

            return true;
        }
    }

    public class Solution
    {
        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            if (prerequisites.GetLength(0) == 0)
                return true;

            bool[] visited = new bool[numCourses];
            List<int>[] graph = new List<int>[numCourses];

            for (int i = 0; i <= numCourses - 1; i++)
                graph[i] = new List<int>();

            for (int i = 0; i <= prerequisites.GetLength(0) - 1; i++)
                graph[prerequisites[i, 0]].Add(prerequisites[i, 1]);

            for (int i = 0; i <= graph.Length - 1; i++)
                if (!DFS(graph, visited, i))
                    return false;

            return true;
        }

        private bool DFS(List<int>[] graph, bool[] visited, int currentCourseStart)
        {
            if (visited[currentCourseStart])
                return false;
            visited[currentCourseStart] = true;
            for (int i = 0; i < graph[currentCourseStart].Count; i++)
            {
                if (!DFS(graph, visited, graph[currentCourseStart][i]))
                    return false;
                graph[currentCourseStart].Remove(i);
            }
            visited[currentCourseStart] = false;

            return true;
        }
    }
}