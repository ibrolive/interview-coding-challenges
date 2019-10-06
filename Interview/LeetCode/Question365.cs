using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question365
    {
        // https://leetcode.com/problems/water-and-jug-problem/discuss/172968/Java-BFS
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (z < 0 || x + y < z)
                return false;

            Queue<int> queue = new Queue<int>();
            HashSet<int> visitd = new HashSet<int>();
            int currentVal = 0,
                currentRound = 0;
            int[] options = new int[] { x, y, -x, -y };

            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                currentRound = queue.Count;

                while (currentRound-- > 0)
                {
                    currentVal = queue.Dequeue();

                    if (currentVal == z)
                        return true;

                    foreach (var item in options)
                    {
                        if (currentVal + item < 0 || currentVal + item > x + y || visitd.Contains(currentVal + item))
                            continue;

                        queue.Enqueue(currentVal + item);
                        visitd.Add(currentVal + item);
                    }
                }
            }

            return false;
        }

        // Maths solution:
        // https://leetcode.com/problems/water-and-jug-problem/discuss/83715/Math-solution-Java-solution
        public bool canMeasureWater2(int x, int y, int z)
        {
            //limit brought by the statement that water is finallly in one or both buckets
            if (x + y < z) return false;

            //case x or y is zero
            if (x == z || y == z || x + y == z) return true;

            //get GCD, then we can use the property of Bézout's identity
            return z % GCD(x, y) == 0;
        }

        public int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
