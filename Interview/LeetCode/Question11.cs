using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question11
    {
        public int MaxArea(int[] height)
        {
            int max = Int32.MinValue,
                leftIndex = 0,
                rightIndex = height.Length - 1;

            while (leftIndex < rightIndex)
            {
                max = Math.Max(max,
                               Math.Min(height[leftIndex], height[rightIndex]) * (rightIndex - leftIndex));

                if (height[leftIndex] <= height[rightIndex])
                    leftIndex++;
                else
                    rightIndex--;
            }

            return max;
        }
    }
}
