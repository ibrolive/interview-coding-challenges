using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question223
    {
        // https://leetcode.com/problems/rectangle-area/discuss/62340/The-tests-are-bad
        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            int area1 = Math.Abs((C - A) * (D - B)),
                area2 = Math.Abs((G - E) * (H - F));

            if (B >= H ||
                F >= D ||
                E >= C ||
                A >= G)
                return area1 + area2;
            else
            {
                int overlapWidth = Math.Min(C, G) - Math.Max(A, E),
                    overlapHeight = Math.Min(D, H) - Math.Max(B, F);

                return area1 + area2 - Math.Abs(overlapHeight * overlapWidth);
            }
        }
    }
}
