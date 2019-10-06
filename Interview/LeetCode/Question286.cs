using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question286
    {
        public static void EntryPoint()
        {
            //int[,] input = new int[,] { { 2147483647, -1, 0, 2147483647 },
            //                            { 2147483647,2147483647,2147483647,-1},
            //                            { 2147483647,-1,2147483647,-1},
            //                            { 0,-1,2147483647,2147483647} };

            int[,] input = new int[,] { { 2147483647, 2147483647, 2147483647 },
                                        { -1,         2147483647, 0},
                                        { 0,          2147483647, 2147483647},
                                        { 0,          2147483647, -1} };

            (new Question286()).WallsAndGates(input);
        }

        // https://leetcode.com/problems/walls-and-gates/solution/
        public void WallsAndGates(int[,] rooms)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            Tuple<int, int> temp = null;
            int[,] directions = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            int row = 0,
                col = 0;

            for (int i = 0; i < rooms.GetLength(0); i++)
                for (int j = 0; j < rooms.GetLength(1); j++)
                    if (rooms[i, j] == 0)
                        queue.Enqueue(new Tuple<int, int>(i, j));

            while (queue.Count != 0)
            {
                temp = queue.Dequeue();

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    row = temp.Item1 + directions[i, 0];
                    col = temp.Item2 + directions[i, 1];

                    if (row < 0 || row > rooms.GetLength(0) - 1 ||
                        col < 0 || col > rooms.GetLength(1) - 1 ||
                        rooms[row, col] != 2147483647)
                        continue;

                    rooms[row, col] = rooms[temp.Item1, temp.Item2] + 1;

                    queue.Enqueue(new Tuple<int, int>(row, col));
                }
            }
        }
    }
}
