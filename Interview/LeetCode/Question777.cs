using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question777
    {
        public static void EntryPoint()
        {
            (new Question777()).CanTransform("RXXLRXRXL", "XRLXXRRLX");
        }

        // https://leetcode.com/problems/swap-adjacent-in-lr-string/discuss/113789/Simple-Java-one-pass-O(n)-solution-with-explaination
        public bool CanTransform(string start, string end)
        {
            int index1 = 0,
                index2 = 0;

            while (index1 < start.Length & index2 < end.Length)
            {
                while (index1 < start.Length && start[index1] == 'X')
                    index1++;

                while (index2 < end.Length && end[index2] == 'X')
                    index2++;

                if (index1 == start.Length ^ index2 == end.Length ||
                    (index1 < start.Length && index2 < end.Length &&
                     (start[index1] != end[index2] ||
                      (start[index1] == 'L' && index1 < index2) ||
                      (start[index1] == 'R' && index1 > index2))))
                    return false;

                index1++;
                index2++;
            }

            return true;
        }
    }
}
