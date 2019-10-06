using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question490
    {
        static int[][] paths = new int[5][];

        public static void EntryPoint()
        {
            for (int i = 0; i < paths.Length; i++)
                paths[i] = new int[5];

            int[][] maze = new int[5][];
            maze[0] = new int[] { 0, 0, 1, 0, 0 };
            maze[1] = new int[] { 0, 0, 0, 0, 0 };
            maze[2] = new int[] { 0, 0, 0, 1, 0 };
            maze[3] = new int[] { 1, 1, 0, 1, 1 };
            maze[4] = new int[] { 0, 0, 0, 0, 0 };

            (new Question490()).HasPath(maze, new int[] { 0, 4 }, new int[] { 1, 2 });

            foreach (var item in paths)
            {
                foreach (var element in item)
                    Console.Write(element + " ");

                Console.Write("\n");
            }

            Console.Write("\n");

            foreach (var item in maze)
            {
                foreach (var element in item)
                    Console.Write(element + " ");

                Console.Write("\n");
            }
        }

        // https://leetcode.com/problems/the-maze/discuss/97101/C-2-solutions-DFS-and-BFS
        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            return DFS(maze, start[0], start[1], destination[0], destination[1], 1);
        }

        public bool DFS(int[][] maze, int r, int c, int destR, int destC, int path)
        {
            paths[r][c] = path;

            if (r == destR && c == destC)
                return true;

            maze[r][c] = -1;

            int rNext = 0;
            int cNext = 0;
            int maxR = maze.Length - 1;
            int maxC = maze[0].Length - 1;

            // roll up
            rNext = r;
            while (rNext > 0 && maze[rNext - 1][c] != 1) rNext--;
            if (rNext != r && maze[rNext][c] == 0 && DFS(maze, rNext, c, destR, destC, ++path)) return true;

            // roll down
            rNext = r;
            while (rNext < maxR && maze[rNext + 1][c] != 1) rNext++;
            if (rNext != r && maze[rNext][c] == 0 && DFS(maze, rNext, c, destR, destC, ++path)) return true;

            // roll left
            cNext = c;
            while (cNext > 0 && maze[r][cNext - 1] != 1) cNext--;
            if (cNext != c && maze[r][cNext] == 0 && DFS(maze, r, cNext, destR, destC, ++path)) return true;

            // roll right
            cNext = c;
            while (cNext < maxC && maze[r][cNext + 1] != 1) cNext++;
            if (cNext != c && maze[r][cNext] == 0 && DFS(maze, r, cNext, destR, destC, ++path)) return true;

            return false;
        }
    }
}
