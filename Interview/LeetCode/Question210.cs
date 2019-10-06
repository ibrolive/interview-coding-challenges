using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question210
    {
        public static void EntryPoint()
        {
            (new Question210()).FindOrder(3, new int[,] { { 1, 0 }, { 2, 0 }, { 0, 2 } });
        }

        bool hasCycle = false;

        public int[] FindOrder(int numCourses, int[,] prerequisites)
        {
            List<int>[] graph = new List<int>[numCourses];
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[numCourses],
                   currentRound = new bool[numCourses];
            int index = 0;
            int[] result = new int[numCourses];

            if (prerequisites != null && prerequisites.Length != 0 && prerequisites.GetLength(0) > 0 && prerequisites.GetLength(1) > 0)
            {
                for (int i = 0; i < prerequisites.GetLength(0); i++)
                {
                    if (graph[prerequisites[i, 1]] == null)
                        graph[prerequisites[i, 1]] = new List<int>();

                    graph[prerequisites[i, 1]].Add(prerequisites[i, 0]);
                }

                for (int i = 0; i < numCourses; i++)
                {
                    TopologicalSort(i, graph, visited, currentRound, stack);

                    if (hasCycle)
                        break;
                }
            }
            else if (numCourses != 0)
                for (int i = 0; i < numCourses; i++)
                    result[i] = i;

            if (!hasCycle)
                while (stack.Count != 0)
                    result[index++] = stack.Pop();
            else
                result = new int[0];

            return result;
        }

        private void TopologicalSort(int currentCourse, List<int>[] graph, bool[] visited, bool[] currentRound, Stack<int> stack)
        {
            if (currentRound[currentCourse])
                hasCycle = true;
            if (!visited[currentCourse])
            {
                visited[currentCourse] = true;
                currentRound[currentCourse] = true;

                if (graph[currentCourse] != null)
                    for (int i = 0; i < graph[currentCourse].Count; i++)
                        TopologicalSort(graph[currentCourse][i], graph, visited, currentRound, stack);

                currentRound[currentCourse] = false;
                stack.Push(currentCourse);
            }
        }
    }
}
