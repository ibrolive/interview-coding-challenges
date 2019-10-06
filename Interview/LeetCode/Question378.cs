using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question378
    {
        // https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/discuss/85182/my-solution-using-binary-search-in-c
        // https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/discuss/85304/%22O(n-log-n)%22-Ruby-solution
        // https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/discuss/85202/C-version-by-SortedList
        // https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/discuss/235686/Java-Solution
        public int KthSmallest(int[,] matrix, int k)
        {
            int r = 0;
            SortedList<int, Tuple<int, int>> s = new SortedList<int, Tuple<int, int>>(new DuplicateKeyComparer<int>());

            for (int i = 0; i < matrix.GetLength(0); i++)
                s.Add(matrix[i, 0], new Tuple<int, int>(i, 0));

            while (k-- > 0)
            {
                r = s.First().Key;
                int x = s.First().Value.Item1, 
                    y = s.First().Value.Item2;

                s.RemoveAt(0);

                if (y < matrix.GetLength(0) - 1)
                    s.Add(matrix[x, y + 1], new Tuple<int, int>(x, y + 1));
            }

            return r;
        }

        public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);
                return result == 0 ? 1 : result;
            }
        }
    }
}
