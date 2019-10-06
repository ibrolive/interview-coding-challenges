using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question325
    {
        public static void EntryPoint()
        {
            (new Question325()).MaxSubArrayLen(new int[] { -1, 1 }, 1);
        }

        public int MaxSubArrayLen(int[] nums, int k)
        {
            if (nums.Length == 0 || nums == null)
                return 0;

            int result = 0;
            int[] matrix = new int[nums.Length];

            matrix[0] = nums[0];
            if (matrix[0] == k)
                result = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                matrix[i] = matrix[i - 1] + nums[i];

                if (matrix[i] == k && i + 1 > result)
                    result = i + 1;
            }

            for (int i = 0; i < nums.Length; i++)
                for (int j = i + 1; j < nums.Length; j++)
                    if (matrix[j] - matrix[i] == k && j - i > result)
                        result = j - i;

            return result;
        }
    }
}
