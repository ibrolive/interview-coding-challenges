using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question698
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sum = nums.Sum();

            if (sum % k > 0)
                return false;

            int target = sum / k;
            int row = nums.Length - 1;

            Array.Sort(nums);

            if (nums[row] > target)
                return false;

            while (row >= 0 && nums[row] == target)
            {
                row--;
                k--;
            }

            return Search(new int[k], row, nums, target);
        }

        public bool Search(int[] groups, int row, int[] nums, int target)
        {
            if (row < 0)
                return true;

            int v = nums[row--];

            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i] + v <= target)
                {
                    groups[i] += v;

                    if (Search(groups, row, nums, target))
                        return true;

                    groups[i] -= v;
                }

                if (groups[i] == 0)
                    break;
            }

            return false;
        }
    }
}
