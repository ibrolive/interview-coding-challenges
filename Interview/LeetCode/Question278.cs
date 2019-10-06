using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question278
    {
        public int FirstBadVersion(int n)
        {
            int start = 1, mid = 0, end = n;

            while (start < end)
            {
                mid = start + (end - start) / 2;

                if (IsBadVersion(mid))
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            return start;
        }

        private bool IsBadVersion(int mid)
        {
            throw new NotImplementedException();
        }
    }
}