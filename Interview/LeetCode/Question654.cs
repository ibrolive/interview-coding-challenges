using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.LeetCode
{
    class Question654
    {
        public static void EntryPoint()
        {
            (new Question654()).ConstructMaximumBinaryTree(new int[] { 3, 2, 1, 6, 0, 5 });
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return BuildTree(nums, 0, nums.Length - 1);
        }

        private TreeNode BuildTree(int[] nums, int start, int end)
        {
            int currentMaxIndex = FindMaxIndex(nums, start, end);
            TreeNode root = new TreeNode(nums[currentMaxIndex]);

            if (start <= currentMaxIndex - 1)
                root.left = BuildTree(nums, start, currentMaxIndex - 1);

            if (currentMaxIndex + 1 <= end)
                root.right = BuildTree(nums, currentMaxIndex + 1, end);

            return root;
        }

        private int FindMaxIndex(int[] input, int start, int end)
        {
            int i = start,
                j = end,
                currentMaxIndex = end,
                currentMax = input[j--];

            while (i <= j)
            {
                while (i <= j && input[i] <= currentMax)
                    i++;

                if (i <= j)
                {
                    currentMaxIndex = i;
                    currentMax = input[i++];
                }

                while (i <= j && input[j] <= currentMax)
                    j--;

                if (i <= j)
                {
                    currentMaxIndex = j;
                    currentMax = input[j--];
                }
            }

            return currentMaxIndex;
        }
    }
}