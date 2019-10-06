using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question505
    {
        // https://leetcode.com/problems/the-maze-ii/solution/
        public int ShortestDistance(int[][] maze, int[] start, int[] destination)
        {
            int[,] dirs = { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 } };
            int[][] distance = new int[maze.Length][];
            int[] temp = null;
            int x = 0, y = 0, count = 0;
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < maze.Length; i++)
                distance[i] = Enumerable.Repeat(int.MaxValue, maze[0].Length).ToArray();

            distance[start[0]][start[1]] = 0;

            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                temp = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    x = temp[0] + dirs[i, 0];
                    y = temp[1] + dirs[i, 1];
                    count = 0;

                    while (x >= 0 && y >= 0 && x < maze.Length && y < maze[0].Length && maze[x][y] == 0)
                    {
                        x += dirs[i, 0];
                        y += dirs[i, 1];

                        count++;
                    }

                    if (distance[temp[0]][temp[1]] + count < distance[x - dirs[i, 0]][y - dirs[i, 1]])
                    {
                        distance[x - dirs[i, 0]][y - dirs[i, 1]] = distance[temp[0]][temp[1]] + count;

                        queue.Enqueue(new int[] { x - dirs[i, 0], y - dirs[i, 1] });
                    }
                }
            }

            return distance[destination[0]][destination[1]] == int.MaxValue ? -1 : distance[destination[0]][destination[1]];
        }
    }
}
