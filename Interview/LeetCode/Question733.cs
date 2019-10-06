using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question733
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int[][] visited = new int[image.Length][];

            for (int i = 0; i < visited.Length; i++)
                visited[i] = new int[image[0].Length];

            Helper(image, visited, sr, sc, newColor);

            return image;
        }

        private void Helper(int[][] image, int[][] visited, int row, int col, int color)
        {
            visited[row][col] = 1;

            if (row - 1 > -1 && visited[row - 1][col] != 1 && image[row - 1][col] == image[row][col])
                Helper(image, visited, row - 1, col, color);

            if (col - 1 > -1 && visited[row][col - 1] != 1 && image[row][col - 1] == image[row][col])
                Helper(image, visited, row, col - 1, color);

            if (row + 1 < image.Length && visited[row + 1][col] != 1 && image[row + 1][col] == image[row][col])
                Helper(image, visited, row + 1, col, color);

            if (col + 1 < image[0].Length && visited[row][col + 1] != 1 && image[row][col + 1] == image[row][col])
                Helper(image, visited, row, col + 1, color);

            image[row][col] = color;
        }
    }
}
