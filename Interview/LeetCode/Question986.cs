using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question986
    {
        public static void EntryPoint()
        {
            (new Question986()).IntervalIntersection(utility.ConvertStringToIntArray("[4,6],[7,8],[10,17]"), utility.ConvertStringToIntArray("[5,10]"));
        }

        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            List<int[]> result = new List<int[]>();
            int aCurrent = 0,
                bCurrent = 0;

            while (aCurrent < A.Length && bCurrent < B.Length)
                if (A[aCurrent][0] == B[bCurrent][1])
                    result.Add(new int[] { B[bCurrent][1], B[bCurrent++][1] });
                else if (A[aCurrent][1] == B[bCurrent][0])
                    result.Add(new int[] { A[aCurrent][1], A[aCurrent++][1] });
                else if (A[aCurrent][1] < B[bCurrent][0])
                    aCurrent++;
                else if (A[aCurrent][0] > B[bCurrent][1])
                    bCurrent++;
                else if (A[aCurrent][0] <= B[bCurrent][0] && A[aCurrent][1] > B[bCurrent][0])
                {
                    if (A[aCurrent][1] <= B[bCurrent][1])
                        result.Add(new int[] { B[bCurrent][0], A[aCurrent++][1] });
                    else
                        result.Add(new int[] { B[bCurrent][0], B[bCurrent++][1] });
                }
                else if (A[aCurrent][0] >= B[bCurrent][0] && A[aCurrent][0] < B[bCurrent][1])
                {
                    if (A[aCurrent][1] >= B[bCurrent][1])
                        result.Add(new int[] { A[aCurrent][0], B[bCurrent++][1] });
                    else
                        result.Add(new int[] { A[aCurrent][0], A[aCurrent++][1] });
                }

            return result.ToArray();
        }
    }
}
