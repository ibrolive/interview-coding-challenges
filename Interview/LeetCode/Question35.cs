using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Question35
    {
        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int i = 0, j = nums.Length - 1, k = 0;

            while (i <= j)
            {
                k = (i + j) / 2;

                if (nums[k] == target)
                    return k;
                else if (nums[k] < target)
                    i = k + 1;
                else
                    j = k - 1;
            }

            return nums[k] < target ? k + 1 : k;
        }
    }
}
