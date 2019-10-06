using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question163
    {
        public static void EntryPoint()
        {
            (new Question163()).FindMissingRanges(new int[] { -2147483648, -2147483648, 0, 2147483647, 2147483647 }, -2147483648, 2147483647);
        }

        public List<string> FindMissingRanges(int[] a, int lo, int hi)
        {
            List<string> res = new List<string>();

            // the next number we need to find
            int next = lo;

            for (int i = 0; i < a.Length; i++)
            {
                // not within the range yet
                if (a[i] < next) continue;

                // continue to find the next one
                if (a[i] == next)
                {
                    next++;
                    continue;
                }

                // get the missing range string format
                res.Add(getRange(next, a[i] - 1));

                if (a[i] == int.MaxValue)
                    break;

                // now we need to find the next number
                next = a[i] + 1;
            }

            // do a final check
            if (next <= hi && a[a.Length - 1] < int.MaxValue) res.Add(getRange(next, hi));

            return res;
        }

        private string getRange(int n1, int n2)
        {
            return (n1 == n2) ? n1.ToString() : String.Format("{0}->{1}", n1, n2);
        }
    }
}
