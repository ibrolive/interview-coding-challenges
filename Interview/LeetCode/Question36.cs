using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question36
    {
        public static void EntryPoint()
        {
            //char[,] board =
            //{
            //    {'.','.','.','.','5','.','.','1','.'},
            //    {'.','4','.','3','.','.','.','.','.'},
            //    {'.','.','.','.','.','3','.','.','1'},
            //    {'8','.','.','.','.','.','.','2','.'},
            //    {'.','.','2','.','7','.','.','.','.'},
            //    {'.','1','5','.','.','.','.','.','.'},
            //    {'.','.','.','.','.','2','.','.','.'},
            //    {'.','2','.','9','.','.','.','.','.'},
            //    {'.','.','4','.','.','.','.','.','.'},
            //};

            char[,] board =
            {
                {'.','.','.','.','.','.','5','.','.'},
                {'.','.','.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.','.','.'},
                {'9','3','.','.','2','.','4','.','.'},
                {'.','.','7','.','.','.','3','.','.'},
                {'.','.','.','.','.','.','.','.','.'},
                {'.','.','.','3','4','.','.','.','.'},
                {'.','.','.','.','.','3','.','.','.'},
                {'.','.','.','.','.','5','2','.','.'},
            };

            (new Question36()).IsValidSudoku(board);
        }

        public bool IsValidSudoku(char[,] board)
        {
            char[] elementsInRow = null,
                   elementsInColumn = null;
            int indexX = 0,
                indexY = 0;

            while (indexX < board.GetLength(1) && indexY < board.GetLength(0))
            {
                elementsInRow = new char[9];
                elementsInColumn = new char[9];

                for (int i = 0; i < board.GetLength(1); i++)
                    if ((board[indexY, i] != '.' && elementsInRow[board[indexY, i] - '0' - 1] != '\0') ||
                        (indexY % 3 == 0 && i % 3 == 0 && !CheckSquare(board, i, indexY)))
                        return false;
                    else if (board[indexY, i] != '.')
                        elementsInRow[board[indexY, i] - '0' - 1] = board[indexY, i];

                for (int i = 0; i < board.GetLength(0); i++)
                    if (board[i, indexX] != '.' && elementsInColumn[board[i, indexX] - '0' - 1] != '\0')
                        return false;
                    else if (board[i, indexX] != '.')
                        elementsInColumn[board[i, indexX] - '0' - 1] = board[i, indexX];

                indexX++;
                indexY++;
            }

            return true;
        }

        private bool CheckSquare(char[,] board, int indexX, int indexY)
        {
            char[] elements = new char[9];

            for (int i = indexY; i < indexY + 3; i++)
                for (int j = indexX; j < indexX + 3; j++)
                    if (board[i, j] != '.' && elements[board[i, j] - '0' - 1] != '\0')
                        return false;
                    else if (board[i, j] != '.')
                        elements[board[i, j] - '0' - 1] = board[i, j];

            return true;
        }
    }
}
