using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question75
    {
        public void SortColors(int[] nums)
        {
            int redCount = 0, whiteCount = 0, blueCount = 0, index = 0;

            foreach (var item in nums)
                if (item == 0)
                    redCount++;
                else if (item == 1)
                    whiteCount++;
                else
                    blueCount++;

            while (redCount-- > 0)
                nums[index++] = 0;

            while (whiteCount-- > 0)
                nums[index++] = 1;

            while (blueCount-- > 0)
                nums[index++] = 2;
        }
    }
}