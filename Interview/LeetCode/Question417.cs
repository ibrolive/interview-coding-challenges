using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question417
    {
        public static void EntryPoint()
        {
            int[][] matrix = new int[5][];
            matrix[0] = new int[] { 1, 2, 2, 3, 5 };
            matrix[1] = new int[] { 3, 2, 3, 4, 4 };
            matrix[2] = new int[] { 2, 4, 5, 3, 1 };
            matrix[3] = new int[] { 6, 7, 1, 4, 5 };
            matrix[4] = new int[] { 5, 1, 1, 2, 4 };

            (new Question417()).PacificAtlantic(matrix);
        }

        bool hitLeftTop = false,
             hitRightBottom = false;

        public IList<int[]> PacificAtlantic(int[][] matrix)
        {
            int[][] visited = new int[matrix.Length][];
            IList<int[]> result = new List<int[]>();

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    for (int k = 0; k < visited.Length; k++)
                        visited[k] = new int[matrix[0].Length];

                    Helper(matrix, visited, i, j);

                    if (hitLeftTop && hitRightBottom)
                        result.Add(new int[] { i, j });

                    hitLeftTop = false;
                    hitRightBottom = false;
                }

            return result;
        }

        private void Helper(int[][] matrix, int[][] visited, int row, int col)
        {
            visited[row][col] = 1;

            if (row == 0 || col == 0)
                this.hitLeftTop = true;

            if (row == matrix.Length - 1 || col == matrix[0].Length - 1)
                this.hitRightBottom = true;

            if (row - 1 > -1 && matrix[row - 1][col] <= matrix[row][col] && visited[row - 1][col] != 1)
                Helper(matrix, visited, row - 1, col);

            if (row + 1 < matrix.Length && matrix[row + 1][col] <= matrix[row][col] && visited[row + 1][col] != 1)
                Helper(matrix, visited, row + 1, col);

            if (col - 1 > -1 && matrix[row][col - 1] <= matrix[row][col] && visited[row][col - 1] != 1)
                Helper(matrix, visited, row, col - 1);

            if (col + 1 < matrix[0].Length && matrix[row][col + 1] <= matrix[row][col] && visited[row][col + 1] != 1)
                Helper(matrix, visited, row, col + 1);
        }
    }
}
