using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question370
    {
        public static void EntryPoint()
        {
            (new Question370()).GetModifiedArray(10, new int[,] { { 2, 4, 6 }, { 5, 6, 8 }, { 1, 9, -4 } });
        }

        // https://leetcode.com/problems/range-addition/discuss/84225/Detailed-explanation-if-you-don't-understand-especially-%22put-negative-inc-at-endIndex+1%22
        public int[] GetModifiedArray(int length, int[,] updates)
        {
            int[] result = new int[length],
                  temp = new int[length + 1];

            for (int i = 0; i < updates.GetLength(0); i++)
            {
                temp[updates[i, 0]] += updates[i, 2];
                temp[updates[i, 1] + 1] += -updates[i, 2];
            }

            result[0] = temp[0];

            for (int i = 1; i < result.Length; i++)
                result[i] = result[i - 1] + temp[i];

            return result;
        }
    }
}
