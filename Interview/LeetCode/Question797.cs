using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question797
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> currentPath = new List<int>();

            currentPath.Add(0);

            Helper(graph, 0, currentPath, result);

            return result;
        }

        private void Helper(int[][] graph, int currentNode, List<int> currentPath, IList<IList<int>> result)
        {
            if (currentNode == graph.Length - 1)
                result.Add(new List<int>(currentPath));
            else
                foreach (var item in graph[currentNode])
                {
                    currentPath.Add(item);

                    Helper(graph, item, currentPath, result);

                    currentPath.RemoveAt(currentPath.Count - 1);
                }
        }
    }
}
