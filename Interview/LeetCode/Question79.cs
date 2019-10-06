using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question79
    {
        public static void EntryPoint()
        {
            char[,] board = new char[,] { { 'a', 'b' } };
            (new Question79()).Exist(board, "ba");
        }

        public bool Exist(char[,] board, string word)
        {
            for (int i = 0; i <= board.GetLength(0) - 1; i++)
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                    if (DFS(board, i, j, word, 0))
                        return true;

            return false;
        }

        private bool DFS(char[,] board, int row, int col, string word, int index)
        {
            if (index == word.Length)
                return true;

            if (row < 0 || col < 0 || row > board.GetLength(0) - 1 || col > board.GetLength(1) - 1 || board[row, col] != word[index])
                return false;

            char temp = board[row, col];
            board[row, col] = '0';
            bool result = DFS(board, row - 1, col, word, index + 1) ||
                          DFS(board, row + 1, col, word, index + 1) ||
                          DFS(board, row, col - 1, word, index + 1) ||
                          DFS(board, row, col + 1, word, index + 1);
            board[row, col] = temp;

            return result;
        }
    }
}