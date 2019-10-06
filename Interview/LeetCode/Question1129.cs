using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Interview.DataStructure;

namespace Interview.LeetCode
{
    class Question1129
    {
        public static void EntryPoint()
        {
            (new Question1129()).ShortestAlternatingPaths(5,
                                                          utility.ConvertStringToIntArray("[0,1],[1,3],[2,1],[3,1],[2,0],[1,0],[0,2]"),
                                                          utility.ConvertStringToIntArray("[1,2],[3,2],[2,4],[3,3],[0,3],[1,4],[0,1],[0,2],[0,0],[4,1]"));
        }

        public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges)
        {
            int[] result = new int[n];
            Dictionary<int, List<int>> red = new Dictionary<int, List<int>>(),
                                       blue = new Dictionary<int, List<int>>();
            Queue<Point> q = new Queue<Point>();
            HashSet<int> redUsed = new HashSet<int>(),
                         blueUsed = new HashSet<int>();
            int distance = 0;

            for (int i = 0; i < n; i++)
                result[i] = -1;

            result[0] = 0;

            foreach (int[] edge in red_edges)
            {
                if (!red.ContainsKey(edge[0]))
                    red.Add(edge[0], new List<int>());

                red[edge[0]].Add(edge[1]);
            }

            foreach (int[] edge in blue_edges)
            {
                if (!blue.ContainsKey(edge[0]))
                    blue.Add(edge[0], new List<int>());

                blue[edge[0]].Add(edge[1]);
            }

            q.Enqueue(new Point(0, Color.RED));
            q.Enqueue(new Point(0, Color.BLUE));

            redUsed.Add(0);
            blueUsed.Add(0);

            while (q.Count > 0)
            {
                int size = q.Count;

                while (size-- > 0)
                {
                    Point cur = q.Dequeue();

                    if (result[cur.node] == -1 || result[cur.node] > distance)
                        result[cur.node] = distance;

                    Dictionary<int, List<int>> nextMap = (cur.color == Color.RED ? blue : red);
                    HashSet<int> nextUsed = (cur.color == Color.RED ? blueUsed : redUsed);

                    if (nextMap.ContainsKey(cur.node))
                        foreach (int next in nextMap[cur.node])
                            if (!nextUsed.Contains(next))
                            {
                                nextUsed.Add(next);
                                q.Enqueue(new Point(next, cur.color == Color.RED ? Color.BLUE : Color.RED));
                            }
                }

                distance++;
            }

            return result;
        }

        class Point
        {
            public int node;
            public Color color;

            public Point(int node, Color color)
            {
                this.node = node;
                this.color = color;
            }
        }

        enum Color
        {
            RED,
            BLUE
        }
    }
}
