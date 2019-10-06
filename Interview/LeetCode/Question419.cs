using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question419
    {
        public int CountBattleships(char[,] board)
        {
            int result = 0;

            for (int i = 0; i <= board.GetLength(0) - 1; i++)
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                {
                    if (board[i, j] == '.' || (i > 0 && board[i - 1, j] == 'X') || (j > 0 && board[i, j - 1] == 'X'))
                        continue;
                    result++;
                }

            return result;
        }
    }
}