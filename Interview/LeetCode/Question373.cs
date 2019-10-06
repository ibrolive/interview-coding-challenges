using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question373
    {
        public static void EntryPoint()
        {
            (new Question373()).KSmallestPairs(new int[] { 1, 1, 2 }, new int[] { 1, 2, 3 }, 10);
            //(new Question373()).KSmallestPairs(new int[] { 1, 2, 4, 5, 6 }, new int[] { 3, 5, 7, 9 }, 3);
            //(new Question373()).KSmallestPairs(new int[] { 1, 7, 11 }, new int[] { 2, 4, 6 }, 3);
            //(new Question373()).KSmallestPairs(new int[] { 1 }, new int[] { 3, 5, 6, 7, 8, 100 }, 4);
        }

        // https://leetcode.com/problems/find-k-pairs-with-smallest-sums/discuss/84551/simple-Java-O(KlogK)-solution-with-explanation
        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            if (nums1 == null || nums1.Length == 0 || nums2 == null || nums2.Length == 0)
                return new List<int[]>();

            IList<int[]> result = new List<int[]>();
            List<Tuple<int, int, int>> temp = new List<Tuple<int, int, int>>();
            Tuple<int, int, int> minTuple = new Tuple<int, int, int>(0, 0, 0);
            int min = Int32.MaxValue;

            for (int i = 0; i < nums1.Length && i < k; i++)
                temp.Add(new Tuple<int, int, int>(nums1[i], nums2[0], 0));

            while (temp.Count > 0 && k-- > 0)
            {
                min = Int32.MaxValue;

                for (int l = 0; l < temp.Count; l++)
                    if (temp[l].Item1 + temp[l].Item2 < min)
                    {
                        min = temp[l].Item1 + temp[l].Item2;
                        minTuple = temp[l];
                    }

                result.Add(new int[] { minTuple.Item1, minTuple.Item2 });
                temp.Remove(minTuple);

                if (minTuple.Item3 == nums2.Length - 1)
                    continue;
                else
                    temp.Add(new Tuple<int, int, int>(minTuple.Item1, nums2[minTuple.Item3 + 1], minTuple.Item3 + 1));
            }

            return result;
        }
    }
}
