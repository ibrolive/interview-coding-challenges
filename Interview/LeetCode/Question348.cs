using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question348
    {
    }

    // https://leetcode.com/problems/design-tic-tac-toe/discuss/81898/Java-O(1)-solution-easy-to-understand
    public class TicTacToe
    {
        int[] rows = null,
              columns = null;
        int diagonal = 0,
            anti_diagonal = 0;

        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            rows = new int[n];
            columns = new int[n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            int toAdd = player == 1 ? 1 : -1;

            rows[row] += toAdd;
            columns[col] += toAdd;

            if (row == col)
                diagonal += toAdd;

            if (row == rows.Length - 1 - col)
                anti_diagonal += toAdd;

            if (Math.Abs(rows[row]) == rows.Length ||
                Math.Abs(columns[col]) == rows.Length ||
                Math.Abs(diagonal) == rows.Length ||
                Math.Abs(anti_diagonal) == rows.Length)
                return player;

            return 0;
        }
    }
}
