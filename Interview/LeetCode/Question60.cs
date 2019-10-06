using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question60
    {
        public static void EntryPoint()
        {
            (new Question60()).GetPermutation(3, 3);
        }

        // https://leetcode.com/problems/permutation-sequence/discuss/22507/%22Explain-like-I'm-five%22-Java-Solution-in-O(n)
        // https://leetcode.com/problems/permutation-sequence/discuss/22665/Clean-Java-Solution
        public string GetPermutation(int n, int k)
        {
            List<int> notUsed = new List<int>();

            int weight = 1;

            for (int i = 1; i <= n; i++)
            {
                notUsed.Add(i);
                if (i == n)
                    break;
                weight = weight * i;
            }

            String res = "";
            k = k - 1;
            while (true)
            {
                res = res + notUsed[k / weight];
                notUsed.RemoveAt(k / weight);
                k = k % weight;
                if (notUsed.Count == 0)
                    break;
                weight = weight / notUsed.Count();
            }

            return res;
        }
    }
}
