using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question886
    {
        public static void EntryPoint()
        {
            int[][] dislikes = new int[4][];
            dislikes[0] = new int[] { 1, 2 };
            dislikes[1] = new int[] { 2, 3 };
            dislikes[2] = new int[] { 1, 4 };
            dislikes[3] = new int[] { 3, 4 };

            (new Question886()).PossibleBipartition(4, dislikes);

            //int[][] dislikes = new int[3][];
            //dislikes[0] = new int[] { 1, 2 };
            //dislikes[1] = new int[] { 2, 3 };
            //dislikes[2] = new int[] { 1, 4 };

            //(new Question886()).PossibleBipartition(4, dislikes);
        }

        List<int>[] graph = null;
        Dictionary<int, int> color = new Dictionary<int, int>();

        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            graph = new List<int>[N + 1];

            for (int i = 1; i <= N; ++i)
                graph[i] = new List<int>();

            foreach (int[] edge in dislikes)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            for (int node = 1; node <= N; ++node)
                if (!color.ContainsKey(node) && !dfs(node, 0))
                    return false;

            return true;
        }

        public bool dfs(int node, int c)
        {
            if (color.ContainsKey(node))
                return color[node] == c;

            color.Add(node, c);

            foreach (int nei in graph[node])
                if (!dfs(nei, c ^ 1))
                    return false;

            return true;
        }
    }
}
