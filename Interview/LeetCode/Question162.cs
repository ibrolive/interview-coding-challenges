using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question162
    {
        public int FindPeakElement(int[] nums)
        {
            if (nums == null || nums.Length == 1)
                return 0;

            int currentPeak = int.MinValue, peakIndex = -1, index1 = 0, index2 = 1;

            while (index2 <= nums.Length - 1)
            {
                if (nums[index1] < nums[index2] && index2 + 1 > nums.Length - 1 && nums[index2] > currentPeak)
                    peakIndex = index2;

                if (nums[index1] > nums[index2] && nums[index1] > currentPeak)
                {
                    currentPeak = nums[index1];
                    peakIndex = index1;
                }

                index1 = index2;
                index2++;
            }

            return peakIndex;
        }
    }
}